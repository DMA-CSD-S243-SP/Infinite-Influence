using Microsoft.Data.SqlClient;
using System.Data;

namespace DataAccessLibrary.Interfaces;

/// <summary>
/// BaseDao serves as the foundational class for all Data Access Objects (DAOs) in the application. 
/// it houses the connectionString and provides a method to create database connections.
/// </summary>
/// 12-11-2025 11:00 - Anders
public abstract class BaseDao
{
    public String connectionString { get; private set; }

    protected BaseDao(string connectionString)
    {
        this.connectionString = connectionString;
    }

    //Method to create and return a database connection
    public IDbConnection createConnection()
    {
        return new SqlConnection(connectionString);
    }
}
