using System;
using System.IO;

namespace SingletonPattern
{
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
