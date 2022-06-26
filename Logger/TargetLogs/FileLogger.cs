using System.IO;

namespace SimpleLogger.TargetLogs
{
    public class FileLogger : LoggerBase
    {
        private readonly string path = "log.txt";

        public override void Log(LogMessage logMessage)
        {
            using (StreamWriter sw = new(path, true))
                sw.WriteLine(logMessage.ToString());
        }
    }
}