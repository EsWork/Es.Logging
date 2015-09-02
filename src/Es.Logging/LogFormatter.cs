using System;
using System.Globalization;

namespace Es.Logging
{
    public static class LogFormatter
    {
        /// <summary>
        /// Format the log information content
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="error">The Exception.</param>
        /// <returns>System.String.</returns>
        public static string Formatter(string message, Exception error) {
            if (message == null && error == null) {
                throw new InvalidOperationException("Not found the message or exception information to create a log message.");
            }

            if (message == null) {
                return error.ToString();
            }

            if (error == null) {
                return message;
            }

            return string.Format(CultureInfo.InvariantCulture, "{0}{1}{2}", message, Environment.NewLine, error.ToString());
        }
    }
}