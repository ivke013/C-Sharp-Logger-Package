using System;
using MySql.Data.MySqlClient;

namespace VFM.Core.Logger.src
{
    /// <summary>
    /// MySQL implementation of IDatabaseLogProvider.
    /// </summary>
    public class MySqlLogProvider : IDatabaseLogProvider
    {
        private readonly string _connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="MySqlLogProvider"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string for the MySQL database.</param>
        public MySqlLogProvider(string connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        /// <inheritdoc />
        public void InsertLog(DateTime timestamp, string level, string message, string exception)
        {
            using (var connection = new MySqlConnection(_connectionString))
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
