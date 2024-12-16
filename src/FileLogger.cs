///
/// FileLogger
/// @author: Ivan Stojmenovic 
/// @email: office.stojmenovic@gmail.com
/// 
using System;
using System.IO;

namespace VFM.Core.Logger
{
    /// <summary>
    /// FileLogger is an implementation of the ILogger interface that logs messages to a specified file.
    /// This class supports logging at various severity levels and allows for optional exception logging.
    /// </summary>
    public class FileLogger : ILogger
    {
        private readonly string _logFilePath;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileLogger"/> class.
        /// </summary>
        /// <param name="logFilePath">The path of the log file where messages will be recorded.</param>
        public FileLogger(string logFilePath)
        {
            if (string.IsNullOrWhiteSpace(logFilePath))
            {
                throw new ArgumentException("Log file path cannot be null or empty.", nameof(logFilePath));
            }

            _logFilePath = logFilePath;

            // Ensure the directory exists
            var directory = Path.GetDirectoryName(_logFilePath);
            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        /// <inheritdoc />
        public void Debug(string message) => Log(LogLevel.Debug, message);

        /// <inheritdoc />
        public void Info(string message) => Log(LogLevel.Info, message);

        /// <inheritdoc />
        public void Warn(string message) => Log(LogLevel.Warn, message);

        /// <inheritdoc />
        public void Error(string message) => Log(LogLevel.Error, message);

        /// <inheritdoc />
        public void Fatal(string message) => Log(LogLevel.Fatal, message);

        /// <inheritdoc />
        public void Fatal(string message, Exception exception)
        {
            var exceptionDetails = exception != null ? $"\nException: {exception}" : string.Empty;
            Log(LogLevel.Fatal, $"{message}{exceptionDetails}");
        }

        /// <inheritdoc />
        public void Log(LogLevel level, string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentException("Log message cannot be null or empty.", nameof(message));
            }

            var logEntry = $"{DateTime.UtcNow:yyyy-MM-dd HH:mm:ss.fff} [{level}] {message}";
            WriteToFile(logEntry);
        }

        /// <summary>
        /// Writes a log entry to the specified log file.
        /// </summary>
        /// <param name="logEntry">The formatted log entry to write.</param>
        private void WriteToFile(string logEntry)
        {
            try
            {
                // Write the log entry to the file
                using (var writer = new StreamWriter(_logFilePath, true))
                {
                    writer.WriteLine(logEntry);
                }
            }
            catch (IOException ex)
            {
                // Handle IO exceptions gracefully, perhaps log to an alternative destination in future versions
                Console.Error.WriteLine($"Failed to write to log file. Error: {ex.Message}");
            }
        }
    }
}
