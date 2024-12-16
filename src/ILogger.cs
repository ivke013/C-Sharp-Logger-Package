///
/// Logger
/// @author: Ivan Stojmenovic 
/// @email: office.stojmenovic@gmail.com
/// 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VFM.Core.Logger
{
    /// <summary>
    /// Defines a logging interface for recording messages at various levels of severity.
    /// This interface provides methods for debugging, informational messages, warnings, errors, and fatal conditions.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Logs a debug message, used for detailed troubleshooting information.
        /// </summary>
        /// <param name="message">The debug message to log.</param>
        void Debug(string message);

        /// <summary>
        /// Logs an informational message, used for general application events.
        /// </summary>
        /// <param name="message">The informational message to log.</param>
        void Info(string message);

        /// <summary>
        /// Logs a warning message, used to indicate potential issues or risks.
        /// </summary>
        /// <param name="message">The warning message to log.</param>
        void Warn(string message);

        /// <summary>
        /// Logs an error message, used for recoverable application errors.
        /// </summary>
        /// <param name="message">The error message to log.</param>
        void Error(string message);

        /// <summary>
        /// Logs a fatal message, used for critical application failures that require immediate attention.
        /// </summary>
        /// <param name="message">The fatal error message to log.</param>
        void Fatal(string message);

        /// <summary>
        /// Logs a fatal message with an associated exception, used for critical failures with additional exception details.
        /// </summary>
        /// <param name="message">The fatal error message to log.</param>
        /// <param name="exception">The exception associated with the fatal error.</param>
        void Fatal(string message, Exception exception);

        /// <summary>
        /// Logs a message with a custom log level.
        /// </summary>
        /// <param name="level">The severity level of the log message.</param>
        /// <param name="message">The message to log.</param>
        void Log(LogLevel level, string message);
    }

    /// <summary>
    /// Enum for specifying the severity level of log messages.
    /// </summary>
    public enum LogLevel
    {
        Debug,
        Info,
        Warn,
        Error,
        Fatal
    }
}
