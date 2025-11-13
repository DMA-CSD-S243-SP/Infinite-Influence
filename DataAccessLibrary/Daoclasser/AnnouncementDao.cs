using DataAccessLibrary.Interfaces;
using DataAccessLibrary.Model;
using Dapper;

namespace DataAccessLibrary.Daoclasser;

/// <summary>
/// AnnouncementDAO class is responsible for handling database operations related to Announcements.
/// </summary>
/// 12-11-2025 13:45 - Anders
public class AnnouncementDao : BaseDao, IAnnouncementDao
{
    public AnnouncementDao(string connectionString) : base(connectionString){}

    /// <summary>
    /// creates an announcement in the database using a announcement object
    /// </summary>
    /// <param name="announcement"> the announcement we want to presist into the database</param>
    /// <returns>the Id of the newly created announcement</returns>
    /// <exception cref="Exception"></exception>
    public int CreateAnnouncement(Announcement announcement)
    {
        var query = "INSERT INTO Announcement (Title, Description, BannerUrl, StatusType, CreationDate, VisibilityState, StartDisplayDate, EndDisplayDate, MaximumApplicants, RequiredFollowers)" +
            "OUTPUT INSERTED.Id VALUES (@Title, @Description, @BannerUrl, @StatusType, @CreationDate, @VisibilityState, @StartDisplayDate, @EndDisplayDate, @MaximumApplicants, @RequiredFollowers)";
        try
        {
            using var connection = createConnection();
            return connection.QuerySingle<int>(query, new
            {
                announcement.Title,
                announcement.Description,
                announcement.BannerUrl,
                announcement.StatusType,
                announcement.VisibilityState,
                announcement.CreationDate,
                announcement.StartDisplayDate,
                announcement.EndDisplayDate,
                announcement.MaximumApplicants,
                announcement.RequiredFollowers
            });
        }
        catch (Exception ex)
        {
            throw new Exception("while trying to insert an announcement into the database an error occurred ", ex);
        }
    }    
}
