using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace SimpleLogger
{
    public class Logger
    {
        public enum Level
        {
            Info,
            Warn,
            Debug,
            Error
        }

        public static void Log(Level level, string message)
        {
            var methodBase = GetCallingMethodBase();
            var callingMethod = methodBase.Name;
            var callingClass = methodBase.ReflectedType.Name;

            Log(level, message, callingClass, callingMethod);
        }

        private static void Log(Level level, string message, string callingClass, string callingMethod)
        {
            string path = "log.txt";
            DateTime date = DateTime.Now;

            LogMessage logMessage = new(date, level, callingClass, callingMethod, message);

            using (StreamWriter sw = new(path, true))
            {
                sw.WriteLine(logMessage.ToString());
            }
        }

        public static void Log(Exception ex) => Log(Level.Error, ex.Message);

        private static MethodBase GetCallingMethodBase()
        {
            var stackTrace = new StackTrace();
            for (var i = 0; i < stackTrace.GetFrames().Length; i++)
            {
                var methodBase = stackTrace.GetFrame(i).GetMethod();
                var name = MethodBase.GetCurrentMethod().Name;
                if (!methodBase.Name.Equals("Log") && !methodBase.Name.Equals(name))
                    return methodBase;
            }
            return MethodBase.GetCurrentMethod();
        }
    }
}