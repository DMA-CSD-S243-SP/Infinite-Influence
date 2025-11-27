using Dapper;
using DataAccessLibrary.Interfaces;
using ObjectModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DataAccessLibrary.Daoclasser;

public class InfluencerDao : BaseDao, IInfluencerDao
{
    public InfluencerDao(string connectionString) : base(connectionString){}

    public int createInfluencer(Influencer influencer)
    {
        var query = "INSERT INTO Influencer (Username, Credentials, DisplayName, VerificationStatus, ProfileImageUrl, Location, MainPlatformUrl, Followers)" +
            "OUTPUT INSERTED.Id VALUES (@Username, @Credentials, @DisplayName, @VerificationStatus, @ProfileImageUrl, @Location, @MainPlatformUrl, @Followers)";
        try
        {
            using var connection = createConnection();
            return connection.QuerySingle<int>(query, new
            {
               influencer.Username,
               influencer.Credentials,
               influencer.DisplayName,
               influencer.VerificationStatus,
               influencer.ProfileImageUrl,
               influencer.Location,
               influencer.MainPlatformUrl,
               influencer.Followers
            });
        }
        catch (Exception ex)
        {
            throw new Exception("while trying to insert an influencer into the database an error occurred ", ex);
        }
    }

    public bool JoinAnnouncement(int influencerId, int announcementId)
    {
        string query = "INSERT INTO AnnouncementInfluencer (InfluencerId, AnnouncementId) VALUES (@InfluencerId, @AnnouncementId);";

        /* This SQL statement sorts the AnnouncementInfluencer table by the ApplicationDate.
         * If the given influencer id not found within the first n rows of applications to the given announcement,
         * where n is the MaximumApplicants value of the announcement,
         * then this statement will throw an exception. Otherwise does nothing.*/
        string fullAnnouncementCheck = 
            "DECLARE @TargetAnnouncementId int = @ANID; " +
            "DECLARE @ApplyingInfluencerId int = @INID; " +
            "DECLARE @MaxApplicants int; " +
            "SELECT @MaxApplicants = Announcement.MaximumApplicants FROM Announcement WHERE Announcement.Id = @TargetAnnouncementId; " +
            "IF (NOT EXISTS (" +
            "SELECT InfluencerId FROM (" +
            "SELECT TOP (@MaxApplicants) [InfluencerId] FROM [AnnouncementInfluencer] WHERE [AnnouncementId] = @TargetAnnouncementId ORDER BY AnnouncementInfluencer.ApplicationDate) AS InfluencerId WHERE InfluencerId = @ApplyingInfluencerId)) " +
            "BEGIN " +
                "DECLARE @ErrorMessage nvarchar(2048) = 'Influencer with Id %s was not accepted into Announcement with Id %s'; " +
                "SET @ErrorMessage = FORMATMESSAGE(@ErrorMessage, CAST(@ApplyingInfluencerId AS nvarchar), CAST(@TargetAnnouncementId AS nvarchar)); " +
                "THROW 69420, @ErrorMessage, 1; " +
            "END";
        query += " " + fullAnnouncementCheck;
        try
        {
            using var connection = createConnection();
            connection.Open();

            // By starting a transaction all changes will be undone if a commit is not called before connection is closed.
            // We assume that most ongoing join attempts succeed, thus we allow reading of uncommitted data.
            using IDbTransaction transaction = connection.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted);
            var rowsAffected = connection.Execute(query, new
            {
                InfluencerId = influencerId,
                AnnouncementId = announcementId,
                ANID = announcementId, // For the concurrency check
                INID = influencerId, // For the concurrency check
            }, transaction);
            if (rowsAffected > 0)
            {
                transaction.Commit();
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            throw new Exception("while trying to join an announcement an error occurred ", ex);
        }
    }
}
