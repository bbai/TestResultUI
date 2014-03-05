using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;


namespace AutomateTP
{
    public static class TargetProcessHelper
    {
        public static void AuthenticateTP(string userName, string password)
        {

        }

        public static string HttpGet(string url, string userName, string password)
        {
            return ExecuteRequest(url, userName, password, "Get", string.Empty);
        }

        private static string HttpDelete(string url, string userName, string password)
        {
            return ExecuteRequest(url, userName, password, "DELETE", string.Empty);
        }

        private static string HttpPut(string url, string userName, string password)
        {
            return ExecuteRequest(url, userName, password, "PUT", string.Empty);
        }

        private static string HttpPut(string url, string userName, string password, string bodyXml)
        {
            return ExecuteRequest(url, userName, password, "PUT", bodyXml);
        }

        public static string HttpPost(string url, string userName, string password)
        {
            return ExecuteRequest(url, userName, password, "POST", string.Empty);
        }

        private static string HttpPost(string url, string userName, string password, string bodyXml)
        {
            return ExecuteRequest(url, userName, password, "POST", bodyXml);
        }

        private static string ExecuteRequest(string url, string userName, string password, string method, string bodyXml)
        {
            HttpWebRequest request = GetWebRequest(url, userName, password, method);

            if (string.IsNullOrEmpty(bodyXml) == false)
            {
                byte[] data = UTF8Encoding.UTF8.GetBytes(bodyXml);
                request.ContentLength = data.Length;

                // Send the request:
                using (Stream post = request.GetRequestStream())
                {
                    post.Write(data, 0, data.Length);
                }
            }

            return ReadResponse(request);
        }
        private static string ReadResponse(HttpWebRequest request)
        {
            string result;
            using (HttpWebResponse resp = request.GetResponse()
                                                    as HttpWebResponse)
            {
                StreamReader reader =
                     new StreamReader(resp.GetResponseStream());
                result = reader.ReadToEnd();
            }

            return result;
        }
        private static HttpWebRequest GetWebRequest(string url, string userName, string password, string method)
        {
            HttpWebRequest req = WebRequest.Create(new Uri(url))
                                        as HttpWebRequest;
            req.Method = method;
            req.ContentType = "application/xml";
            req.KeepAlive = false;
            req.Accept = "application/xml";
            string authInfo = userName + ":" + password;
            authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
            req.Headers["Authorization"] = "Basic " + authInfo;
            return req;
        }

        private static string UrlCombine(string uri1, string uri2)
        {
            uri1 = uri1.TrimEnd('/');
            uri2 = uri2.TrimStart('/');
            return string.Format("{0}/{1}", uri1, uri2);
        }
    }
}
