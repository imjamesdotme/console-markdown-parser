using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace console_markdown_parser
{
    class Markdown
    {
        public static string requestMarkdown(string fileContents)
        {
            string markdown = "";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://api.github.com/markdown");
            httpWebRequest.ContentType = "text/plain";
            httpWebRequest.Method = "POST";
            // Github API must have a user agent sent with the request.
            httpWebRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2;)";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = "{ \"text\":" + "\"" + fileContents + "\"" + "}";
                streamWriter.Write(json);
            }
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                markdown = streamReader.ReadToEnd();
            }

            return markdown;
        }
    }
}
