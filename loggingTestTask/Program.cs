using SimpleLogger;
using SimpleLogger.TargetLogs;
using System;

namespace loggingTestTask
{
    class Program
    {
        static void Main()
        {
            LogHelper.Log(LogTarget.Db, LogLevel.Info, "Проверка записи лога в БД");

            LogHelper.Log(LogTarget.File, LogLevel.Info, "Проверка записи лога в файл");

            try
            {
                throw new Exception();
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.Db, ex);
            }

            LogHelper.Log(LogTarget.Db, LogLevel.Warn, "test");

            DbLogger dbLogger = new();
            dbLogger.Log(new LogMessage(DateTime.Now, LogLevel.Debug, "Program", "Main", "Debug"));
        }
    }
}