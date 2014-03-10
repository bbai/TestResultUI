using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Xml;
using System.Windows.Forms;


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
        public static WebClient client;
        public static List<ProjectInfo> GetProjects()
        {
            string url = "http://target.openspan.com/tp/api/v1/Projects/";
            string xmlResults = client.DownloadString(url);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlResults);
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
            string xmlResults = client.DownloadString(url);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlResults);
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

        public static string MakeCR(ProjectInfo project, UserStoryInfo userStory, string name, string NAS, string msg)
        {
            string url = "http://target.openspan.com/tp/api/v1/Bugs";
            string xml = string.Format(@"<Bug Name =""CR - {0}""><Description>&lt;div&gt;{1}\n{2}&lt;/div&gt;</Description><Project Id=""{3}""/><UserStory Id=""{4}""/></Bug>",
                name, NAS, msg, project.ID, userStory.ID);
            client.Headers["Content-Type"] = "application/xml";
            //client.Headers["Content-Length"] = (xml.Length).ToString();
            string bugId = string.Empty;
            try
            {
                string stringResult = client.UploadString(url, "POST", xml);
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(stringResult);
                XmlNode bug = doc.SelectSingleNode("/Bug");
                bugId = bug.Attributes["Id"].Value;
                return bugId;
            }
            catch (WebException e)
            {
                MessageBox.Show(e.Status + " " + e.Message + " " + e.InnerException,
                    "WebException", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
