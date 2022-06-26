using SimpleLogger.TargetLogs;
using System;
using System.Diagnostics;
using System.Reflection;

namespace SimpleLogger
{
    public static class LogHelper
    {
        private static LoggerBase _logger = null;

        public static void Log(LogTarget target, LogLevel level, string message)
        {
            var methodBase = GetCallingMethodBase();
            string callingMethod = methodBase.Name;
            string callingClass = methodBase.ReflectedType.Name;
            DateTime time = DateTime.Now;

            LogMessage logMessage = new(time, level, callingClass, callingMethod, message);

            switch (target)
            {
                case LogTarget.File:
                    _logger = new FileLogger();
                    _logger.Log(logMessage);
                    break;
                case LogTarget.Db:
                    _logger = new DbLogger();
                    _logger.Log(logMessage);
                    break;
                default:
                    return;
            }
        }

        public static void Log(LogTarget target, Exception ex) => Log(target, LogLevel.Error, ex.Message);

        private static MethodBase GetCallingMethodBase()
        {
            StackTrace stackTrace = new();
            for (var i = 0; i < stackTrace.GetFrames().Length; i++)
            {
                var methodBase = stackTrace.GetFrame(i).GetMethod();
                string name = MethodBase.GetCurrentMethod().Name;
                if (!methodBase.Name.Equals("Log") && !methodBase.Name.Equals(name))
                    return methodBase;
            }
            return MethodBase.GetCurrentMethod();
        }
    }
}