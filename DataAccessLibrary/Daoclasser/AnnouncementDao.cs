using DataAccessLibrary.Interfaces;
using Dapper;
using ObjectModel;

namespace DataAccessLibrary.Daoclasser;

/// <summary>
/// AnnouncementDAO class is responsible for handling database operations related to Announcements.
/// </summary>
/// 17-11-2025 10:30 - Anders
public class AnnouncementDao : BaseDao, IAnnouncementDao
{
    public AnnouncementDao(string connectionString) : base(connectionString){}

    /// <summary>
    /// creates an announcement in the database using a announcement object
    /// </summary>
    /// <param name="announcement"> the announcement we want to presist into the database</param>
    /// <returns>the Id of the newly created announcement</returns>
    /// <exception cref="Exception"></exception>
    public int CreateAnnouncement(ObjectModel.Announcement announcement)
    {
        var query = "INSERT INTO Announcement (Title, Description, BannerUrl, StatusType, CreationDate, VisibilityState, StartDisplayDate, EndDisplayDate, MaximumApplicants, RequiredFollowers, CompanyId)" +
            "OUTPUT INSERTED.Id VALUES (@Title, @Description, @BannerUrl, @StatusType, @CreationDate, @VisibilityState, @StartDisplayDate, @EndDisplayDate, @MaximumApplicants, @RequiredFollowers, @CompanyId)";
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
                announcement.RequiredFollowers,
                announcement.CompanyId
            });
        }
        catch (Exception ex)
        {
            throw new Exception("while trying to insert an announcement into the database an error occurred ", ex);
        }
    }

    public bool DeleteAnnouncement(int id)
    {
        var query = "DELETE FROM Announcement WHERE Id = @Id";
        try
        {
            using var connection = createConnection();
            var affectedRows = connection.Execute(query, new { Id = id });
            return affectedRows > 0;
        }
        catch (Exception ex)
        {
            throw new Exception("while trying to delete an announcement from the database an error occurred ", ex);
        }
    }

    /// <summary>
    /// this method returns all of the announcements for the database
    /// </summary>
    /// <returns>an Ienumerable with all Announcements</returns>
    /// <exception cref="Exception"></exception>
    public IEnumerable<ObjectModel.Announcement> GetAllAnnouncements()
    {
        var query = "SELECT * FROM Announcement";
        try
        {
            using var connection = createConnection();
            return connection.Query<ObjectModel.Announcement>(query).ToList();
        }
        catch (Exception ex)
        {
            throw new Exception("while trying to get all announcements from the database an error occurred ", ex);
        }
    }

    /// <summary>
    /// returns one specific announcement based on the given id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>returns a announcement based on the given id</returns>
    /// <exception cref="Exception"></exception>
    public ObjectModel.Announcement? GetAnnouncement(int id)
    {
        var query = "SELECT * FROM Announcement WHERE Id = @Id";
        try
        {
            using var connection = createConnection();
            return connection.QuerySingleOrDefault<ObjectModel.Announcement>(query, new { Id = id });
        }
        catch (Exception ex)
        {
            throw new Exception("while trying to get an announcement from the database an error occurred ", ex);
        }
    }
}
