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
            string query = "SELECT * FROM [Logins] WHERE [Username] = @Username";
            try
            {
                using var connection = createConnection();
                var user = connection.QuerySingle<(string Username, string Credentials, string UserRole)>(query, new
                {
                    Username = username
                });
                if (!password.ValidateHash(user.Credentials))
                {
                    throw new InvalidLoginException("Passwords do not match");
                }

                return new ILoginDao.User(user.Username, user.UserRole);
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
