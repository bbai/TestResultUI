using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Xml;


namespace AutomateTP
{
    public class ProjectInfo
    {
        public string ID { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
    public class UserStoryInfo
    {
        public string ID { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }

    public static class TargetProcessHelper
    {
        public static string authInfo{get; set;}

        public static List<ProjectInfo> GetProjects()
        {
            string url = "http://target.openspan.com/tp/api/v1/Projects/";
            string results = HttpGet(url);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(results);
            List<ProjectInfo> projects = new List<ProjectInfo>();
            foreach (XmlNode node in doc.SelectNodes("/Projects/Project"))
            {
                ProjectInfo projectInfo = new ProjectInfo();
                projectInfo.Name = node.Attributes["Name"].Value;
                projectInfo.ID = node.Attributes["Id"].Value;
                projects.Add(projectInfo);
            }
            return projects;
        }
        public static List<UserStoryInfo> GetUserStories()
        {
            string url = "http://target.openspan.com/tp/api/v1/UserStories/";
            string results = HttpGet(url);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(results);
            List<UserStoryInfo> userStories = new List<UserStoryInfo>();
            foreach (XmlNode node in doc.SelectNodes("/UserStories/UserStory"))
            {
                UserStoryInfo userStoryInfo = new UserStoryInfo();
                userStoryInfo.Name = node.Attributes["Name"].Value;
                userStoryInfo.ID = node.Attributes["Id"].Value;
                userStories.Add(userStoryInfo);
            }
            return userStories;
        }
        public static void MakeCR()
        { 
            string url = "http://target.openspan.com/tp/api/v1/Bugs";
            string xmlBuild = string.Empty;
        }
        #region HttpHelp
        public static string HttpGet(string url)
        {
            return ExecuteRequest(url, "Get", string.Empty);
        }

        private static string HttpDelete(string url)
        {
            return ExecuteRequest(url, "DELETE", string.Empty);
        }

        private static string HttpPut(string url)
        {
            return ExecuteRequest(url, "PUT", string.Empty);
        }

        private static string HttpPut(string url, string bodyXml)
        {
            return ExecuteRequest(url, "PUT", bodyXml);
        }

        public static string HttpPost(string url)
        {
            return ExecuteRequest(url, "POST", string.Empty);
        }

        private static string HttpPost(string url, string bodyXml)
        {
            return ExecuteRequest(url, "POST", bodyXml);
        }

        private static string ExecuteRequest(string url, string method, string bodyXml)
        {
            HttpWebRequest request = GetWebRequest(url, method);
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
        private static HttpWebRequest GetWebRequest(string url, string method)
        {
            HttpWebRequest req = WebRequest.Create(new Uri(url)) as HttpWebRequest;
            req.Method = method;
            req.ContentType = "application/xml";
            req.KeepAlive = false;
            req.Accept = "application/xml";
            req.Headers["Authorization"] = "Basic " + authInfo;
            return req;
        }
        #endregion
        private static string UrlCombine(string uri1, string uri2)
        {
            uri1 = uri1.TrimEnd('/');
            uri2 = uri2.TrimStart('/');
            return string.Format("{0}/{1}", uri1, uri2);
        }
    }
}
