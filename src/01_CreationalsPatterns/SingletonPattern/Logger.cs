using System;
using System.IO;

namespace SingletonPattern
{
    // Szablon singletona
    public class Singleton<T>
        where T : class, new()
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new T();

                return _instance;
            }
        }
    }

    public class ApplicationContext : Singleton<ApplicationContext>
    {
        public string LoggedUser { get; set; }
        public DateTime RunningFrom { get; set; }
        public ApplicationContext() { }

    }

    public class Logger : Singleton<Logger>
    {
        private readonly string path = "log.txt";        

        public Logger() {  }

        public void LogInformation(string message)
        {
            using StreamWriter sw = File.AppendText(path);
            sw.WriteLine($"{DateTime.Now} {message}");
        }
    }
}
