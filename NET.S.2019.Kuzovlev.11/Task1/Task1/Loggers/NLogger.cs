using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace Task1
{
    public class NLogger : ILogger
    {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();

        public void Log(string type, string message)
        {
            switch (type)
            {
                case "Trace":
                    {
                        logger.Trace(message);
                        break;
                    }
                case "Debug":
                    {
                        logger.Debug(message);
                        break;
                    }
                case "Info":
                    {
                        logger.Info(message);
                        break;
                    }
                case "Warn":
                    {
                        logger.Warn(message);
                        break;
                    }
                case "Error":
                    {
                        logger.Error(message);
                        break;
                    }
                case "Fatal":
                    {
                        logger.Fatal(message);
                        break;
                    }
                default:
                    {
                        throw new FormatException(String.Format("The {0} type is not supported.", type));
                    }
            }
        }
    }
}
