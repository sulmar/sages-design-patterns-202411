using System;
using System.IO;

namespace SingletonPattern
{
    public class ApplicationContext
    {
        public string LoggedUser { get; set; }
        public DateTime RunningFrom { get; set; }

        private static ApplicationContext _instance;

        public static ApplicationContext Instance
        {
            get
            {
                if ( _instance == null )
                    _instance = new ApplicationContext();

                return _instance;
            }
        }

        protected ApplicationContext() { }

    }

    public class Logger
    {
        private readonly string path = "log.txt";

        private static Logger _instance;
        public static Logger Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Logger();

                return _instance;
            }
        }

        protected Logger() {  }

        public void LogInformation(string message)
        {
            using StreamWriter sw = File.AppendText(path);
            sw.WriteLine($"{DateTime.Now} {message}");
        }
    }
}
