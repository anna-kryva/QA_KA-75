using System;
using NUnit.Framework;
using Newtonsoft.Json.Linq;
using DropBox;

namespace DropBoxTesting
{
    [TestFixture]
    public class Tests
    {
        private DropBoxClass _dropBox;
        private string _token =
            "sl.AbAchrqP2B-UFKt4MEmmOPlGQJbh2_v3ucDBZk8QMQqton2XcVgiiFTAPFbbVwd0lJOym5BFscl14al41sK1pKS4xmAX6Ck5UeIsweujX8rqszhjGfC2DAFl-nNWLZzJ67G3WW6t";

        private string _hash = "f40c1228343d7e2a632281c986dbb7af3491b9b63ddfd0eb10fee2c913f6cfa7";

        [SetUp]
        public void Startup()
        {
            _dropBox = new DropBoxClass(_token);
        }
        
        [Test]
        public void GetFileMetadata()
        {
            JObject result = _dropBox.GetMetadata("/Get Started with Dropbox Paper.url");
            
            Assert.True(String.CompareOrdinal((string)result.GetValue("status_code"), "200") == 0);
        }

        [Test]
        public void DeleteFile()
        {
            _dropBox.CopyFile("/Get Started with Dropbox Paper.url", "/Get Started with Dropbox Paper Copy.url");
            JObject result = _dropBox.DeleteFile("/Get Started with Dropbox Paper Copy.url");
            Assert.True(String.CompareOrdinal((string)result.GetValue("status_code"), "200") == 0);
        }
    }
}