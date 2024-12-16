///
/// FileLogger
/// @author: Ivan Stojmenovic 
/// @email: office.stojmenovic@gmail.com
///
using System;
using System.Data;
using Microsoft.Data.SqlClient;


namespace VFM.Core.Logger
{
    /// <summary>
    /// SQL Server implementation of IDatabaseLogProvider.
    /// </summary>
    public class SqlServerLogProvider : IDatabaseLogProvider
    {
        private readonly string _connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlServerLogProvider"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string for the SQL Server database.</param>
        public SqlServerLogProvider(string connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        /// <inheritdoc />
        public void InsertLog(DateTime timestamp, string level, string message, string exception)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"
                        INSERT INTO Logs (Timestamp, Level, Message, Exception)
                        VALUES (@Timestamp, @Level, @Message, @Exception)";
                    command.Parameters.AddWithValue("@Timestamp", timestamp);
                    command.Parameters.AddWithValue("@Level", level);
                    command.Parameters.AddWithValue("@Message", message);
                    command.Parameters.AddWithValue("@Exception", exception ?? (object)DBNull.Value);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
