///
/// FileLogger
/// @author: Ivan Stojmenovic 
/// @email: office.stojmenovic@gmail.com
///
namespace VFM.Core.Logger
{
    /// <summary>
    /// Interface for database log providers to support multiple database types.
    /// </summary>
    public interface IDatabaseLogProvider
    {
        /// <summary>
        /// Inserts a log entry into the database.
        /// </summary>
        /// <param name="timestamp">The timestamp of the log entry.</param>
        /// <param name="level">The severity level of the log.</param>
        /// <param name="message">The log message.</param>
        /// <param name="exception">Optional exception details.</param>
        void InsertLog(System.DateTime timestamp, string level, string message, string exception);
    }
}
