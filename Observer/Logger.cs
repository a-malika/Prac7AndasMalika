using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice7
{
    public class Logger
    {
        private static Logger instance;
        private static readonly object _lock = new object();
        private string filePath = "C:/Users/malik/OneDrive/Рабочий стол/out_log.txt";
        private Logger() { }
        public static Logger GetLogger()
        {
            if (instance == null)
            {
                lock(_lock)
                {
                    if (instance == null)
                    {
                        instance = new Logger();
                    }
                }
            }
            return instance;
        }
        public void Log(string message)
        {
            File.AppendAllText(filePath, message + "\n");
        }
    }
}
