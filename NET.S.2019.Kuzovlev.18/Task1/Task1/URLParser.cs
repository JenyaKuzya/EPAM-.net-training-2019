using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public static class URLParser
    {
        private static readonly TextReader textParser = new TextReader();
        private static readonly URLValidator urlValidator = new URLValidator();

        public static List<URL> GetURLs(string inputPath)
        {
            List<string> urls = textParser.Parse(inputPath);

            List<URL> resultList = new List<URL>();

            foreach (string url in urls)
            {
                if (URLValidator.ValidateURL(url))
                {
                    resultList.Add(ParseUrl(url));
                }
            }

            return resultList;
        }

        private static URL ParseUrl(string stringUrl)
        {
            Uri uri = new Uri(stringUrl);
            URL url = new URL
            {
                HostName = uri.Host,
                URI = GetPath(uri.Segments),
                Parameters = GetParameters(uri.Query)
            };

            return url;
        }

        private static List<string> GetPath(string[] segments)
        {
            if (segments.Length > 1)
            {
                return segments
                    .Select(s => s.Trim('/'))
                    .ToList<string>();
            }
            else
            {
                return null;
            }
        }

        private static Dictionary<string, string> GetParameters(string query)
        {
            if (query != string.Empty)
            {
                return query
                    .Trim('?')
                    .Split('&')
                    .Select(p => p.Split('='))
                    .ToDictionary(pair => pair[0], pair => pair[1]);
            }
            else
            {
                return null;
            }
        }
    }
}
