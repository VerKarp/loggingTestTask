using SimpleLogger;

namespace loggingTestTask
{
    class Program
    {
        static void Main()
        {
            Logger.Log(Logger.Level.Info, "Проверка работоспособности");
            Logger.Log(Logger.Level.Warn, "Работает?");
        }
    }
}