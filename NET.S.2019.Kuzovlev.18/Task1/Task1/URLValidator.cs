using System;
using NLog;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class URLValidator
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static bool ValidateURL(string url)
        {
            bool result = Uri.TryCreate(url, UriKind.Absolute, out Uri uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

            if (!result)
                logger.Info(string.Format("{0} is not URL", url));

            return result;
        }
    }
}
