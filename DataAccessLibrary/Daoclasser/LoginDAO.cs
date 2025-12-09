using Dapper;
using DataAccessLibrary.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataAccessLibrary.Interfaces.ILoginDao;

namespace DataAccessLibrary.Daoclasser
{
    public class LoginDAO : BaseDao, ILoginDao
    {
        public LoginDAO(string connectionString) : base(connectionString)
        {

        }

        public ILoginDao.User AttemptLogin(string username, string password)
        {
            // Query combines the id collumns of Company and Influencer into one.
            // Depending on implementation, this could mean a company and an influencer have the same id
            // Current implementation means roles must be enforced on posts, puts, and deletes.
            string query = "SELECT [Logins].[Username], [Credentials], [UserRole], coalesce([Influencer].[Id], [Company].[id]) AS 'Id' " +
                            "FROM [Logins] " +
                            "LEFT JOIN [Influencer] ON [Influencer].[Username] = [Logins].[Username] " +
                            "LEFT JOIN [Company] ON [Logins].[Username] = [Company].[Username]";
            try
            {
                using var connection = createConnection();
                var user = connection.QuerySingle<(string Username, string Credentials, string UserRole, int Id)>(query, new
                {
                    Username = username
                });
                if (!password.ValidateHash(user.Credentials))
                {
                    throw new InvalidLoginException("Passwords do not match");
                }

                return new ILoginDao.User(user.Username, user.UserRole, user.Id);
            }
            catch (InvalidLoginException invex)
            {
                // This just passes the exception thrown in the try statement down the catch.
                throw;
            }
            catch (InvalidOperationException iex)
            {
                // QuerySingle throws an InvalidOperationException if query returns 0 rows, which means username wasn't found.
                throw new InvalidLoginException("Username not found", iex);
            }
            catch (Exception ex)
            {
                throw new Exception("while trying to get all announcements from the database an error occurred ", ex);
            }
        }
    }
}
