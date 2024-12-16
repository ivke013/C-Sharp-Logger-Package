///
/// FileLogger
/// @author: Ivan Stojmenovic 
/// @email: office.stojmenovic@gmail.com
///
using System;

namespace VFM.Core.Logger
{
    /// <summary>
    /// Database logger that supports multiple database types using IDatabaseLogProvider.
    /// </summary>
    public class DatabaseLogger : ILogger
    {
        private readonly IDatabaseLogProvider _logProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseLogger"/> class.
        /// </summary>
        /// <param name="logProvider">The log provider to use for database operations.</param>
        public DatabaseLogger(IDatabaseLogProvider logProvider)
        {
            _logProvider = logProvider ?? throw new ArgumentNullException(nameof(logProvider));
        }

        public void Debug(string message) => Log(LogLevel.Debug, message);

        public void Info(string message) => Log(LogLevel.Info, message);

        public void Warn(string message) => Log(LogLevel.Warn, message);

        public void Error(string message) => Log(LogLevel.Error, message);

        public void Fatal(string message) => Log(LogLevel.Fatal, message);

        public void Fatal(string message, Exception exception)
        {
            var exceptionDetails = exception?.ToString();
            Log(LogLevel.Fatal, $"{message}\nException: {exceptionDetails}");
        }

        public void Log(LogLevel level, string message)
        {
            if (string.IsNullOrWhiteSpace(message))
                throw new ArgumentException("Message cannot be null or empty.", nameof(message));

            _logProvider.InsertLog(DateTime.UtcNow, level.ToString(), message, null);
        }
    }
}
