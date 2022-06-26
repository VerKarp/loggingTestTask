using System;

namespace SimpleLogger
{
    public class LogMessage
    {
        public DateTime Time { get; set; }
        public LogLevel Level { get; set; }
        public string Class { get; set; }
        public string Method { get; set; }
        public string Message { get; set; }

        public LogMessage(DateTime date, LogLevel level, string callingClass, string method, string text)
        {
            Time = date;
            Level = level;
            Class = callingClass;
            Method = method;
            Message = text;
        }

        public override string ToString()
        {
            return string.Format("{0:dd.MM.yyyy HH:mm}: [{1}] - {2}.{3} - {4}", Level.ToString(), Time, Class, Method, Message);
        }
    }
}