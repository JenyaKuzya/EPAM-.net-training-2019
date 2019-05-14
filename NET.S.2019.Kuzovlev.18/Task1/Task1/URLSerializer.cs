using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml.Linq;

namespace Task1
{
    public class URLSerializer
    {
        public void Serialize(string inputPath, string outputPath)
        {
            List<URL> urlList = URLParser.GetURLs(inputPath);

            XElement root = new XElement("urlAddresses");
            XElement node;

            foreach (URL url in urlList)
            {
                node = new XElement("urlAdress");
                node.Add(new XElement("host", new XAttribute("name", url.HostName)));

                if (url.URI != null)
                {
                    node.Add(new XElement("uri", url.URI.Where(path => path.ToString() != "").Select(path => new XElement("segment", path))));
                }

                if (url.Parameters != null)
                {
                    node.Add(new XElement("parameters", url.Parameters.Select(y => new XElement("parametr",
                                                                                    new XAttribute("value", y.Value),
                                                                                    new XAttribute("key", y.Key)))));
                }

                root.Add(node);
            }

            XDocument document = new XDocument(new XDeclaration("1.0", "UTF-8", "yes"), root);
            document.Save(outputPath);
        }
    }
}
