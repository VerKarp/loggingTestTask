using System;

namespace SimpleLogger
{
    class LogMessage
    {
        private readonly DateTime _date;
        private readonly Logger.Level _level;
        private readonly string _class;
        private readonly string _method;
        private readonly string _text;

        public LogMessage() { }

        public LogMessage(DateTime date, Logger.Level level, string callingClass, string method, string text)
        {
            _date = date;
            _level = level;
            _class = callingClass;
            _method = method;
            _text = text;
        }

        public override string ToString()
        {
            return string.Format("{0:dd.MM.yyyy HH:mm}: [{1}] - {2}.{3} - {4}", _level.ToString(), _date, _class, _method, _text);
        }
    }
}