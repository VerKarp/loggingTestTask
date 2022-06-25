using SimpleLogger;
using System;

namespace loggingTestTask
{
    class Program
    {
        static void Main()
        {
            Logger.Log(Logger.Level.Info, "Проверка работоспособности");
            Logger.Log(Logger.Level.Warn, "Работает?");

            try
            {
                throw new Exception();
            }
            catch (Exception e)
            {
                Logger.Log(e);
            }
        }
    }
}