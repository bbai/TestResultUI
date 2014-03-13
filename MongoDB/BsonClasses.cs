using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Mongo
{
    public class TestRun
    {
        [JsonProperty("@userName")]
        public string userName { get; set; }

        [JsonProperty("@testRunName")]
        public string testRunName { get; set; }

        [JsonProperty("@runtimeVersion")]
        public string runtimeVersion { get; set; }

        [JsonProperty("@timeStamp")]
        public string timeStamp { get; set; }

        [JsonProperty("@testRunId")]
        public string testRunId { get; set; }

        [JsonProperty("Configuration")]
        public List<Configuration> Configurations { get; set; }
    }

    public class Configuration
    {
        [JsonProperty("@templateName")]
        public string templateName { get; set; }

        [JsonProperty("@configId")]
        public string configId { get; set; }

        [JsonProperty("@templateId")]
        public string templateId { get; set; }

        [JsonProperty("test-results")]
        public List<TestResult> testResults { get; set; }

        [JsonProperty("@remove")]
        public bool remove { get; set; }
    }

    public class TestResult
    {
        [JsonProperty("@project-id")]
        public string projectId { get; set; }

        [JsonProperty("@project-name")]
        public string projectName { get; set; }

        [JsonProperty("@total")]
        public string total { get; set; }

        [JsonProperty("@not-finish")]
        public string notFinish { get; set; }

        [JsonProperty("@failures")]
        public string failures { get; set; }

        [JsonProperty("@date")]
        public string date { get; set; }

        [JsonProperty("@time")]
        public string time { get; set; }

        [JsonProperty("@test-name")]
        public string testName { get; set; }

        [JsonProperty("@environment")]
        public ConfigEnvironment environment { get; set; }

        [JsonProperty("test-suite")]
        public TestSuite testSuite { get; set; }

        [JsonProperty("@remove")]
        public bool remove { get; set; }
    }

    public class ConfigEnvironment
    {
        [JsonProperty("@ie-version")]
        public string ieVersion { get; set; }

        [JsonProperty("@Java-version")]
        public string JavaVersion { get; set; }

        [JsonProperty("@Architecture")]
        public string Architecture { get; set; }

        [JsonProperty("@os-name")]
        public string osName { get; set; }

        [JsonProperty("@clr-version")]
        public string clrVersion { get; set; }

        [JsonProperty("@os-version")]
        public string osVersion { get; set; }

        [JsonProperty("@platform")]
        public string platform { get; set; }

        [JsonProperty("@cwd")]
        public string cwd { get; set; }

        [JsonProperty("@machine-name")]
        public string machineName { get; set; }

        [JsonProperty("@user")]
        public string user { get; set; }

        [JsonProperty("@user-domain")]
        public string userDomain { get; set; }
    }

    public class TestSuite
    {
        [JsonProperty("@executed")]
        public string executed { get; set; }

        [JsonProperty("@result")]
        public string result { get; set; }

        [JsonProperty("@success")]
        public string success { get; set; }

        [JsonProperty("@total-time")]
        public string totalTime { get; set; }

        [JsonProperty("@project-path")]
        public string projectPath { get; set; }

        [JsonProperty("results")]
        public Results results { get; set; }
    }

    public class Results
    {
        [JsonProperty("test-case")]
        public List<TestCase> TestCases { get; set; }
    }

        public class TestCase
    {
        [JsonProperty("@executed")]
        public string executed { get; set; }

        [JsonProperty("@result")]
        public string result { get; set; }

        [JsonProperty("@success")]
        public string success { get; set; }

        [JsonProperty("@name")]
        public string name { get; set; }

        [JsonProperty("@time")]
        public string time { get; set; }

        [JsonProperty("@remove")]
        public bool remove { get; set; }
    }

    public class Failures
    {
        [JsonProperty("automation")]
        public List<Automation> automation { get; set; }
    }

    public class Automation
    {
        [JsonProperty("@name")]
        public string name { get; set; }
        [JsonProperty("@success")]
        public string success { get; set; }
        [JsonProperty("status")]
        public Status status { get; set; }
    }

    public class Status
    {
        [JsonProperty("@failure-type")]
        public string failureType { get; set; }
        [JsonProperty("@message")]
        public string message { get; set; }
    }
}
