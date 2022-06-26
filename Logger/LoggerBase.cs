namespace SimpleLogger
{
    public enum LogTarget
    {
        File,
        Db
    }

    public enum LogLevel
    {
        Info,
        Warn,
        Debug,
        Error
    }

    public abstract class LoggerBase
    {
        public abstract void Log(LogMessage message);
    }
}