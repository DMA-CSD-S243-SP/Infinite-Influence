using Dapper;
using DataAccessLibrary.Interfaces;
using ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}
