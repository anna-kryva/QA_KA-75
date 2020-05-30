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
            "sl.AbBB9C0HF6JlqJBiVv5r6Sr3SR7EMI1P4GgGYrrCTPvNLvuRKkZWeT93wPlqCuaZkQ93nze_xaT2Y1vgN0EbzwfNRV6urdwbVC3ddG0nwGEmy8bRsTAvwspD778Vl2CrutL4ytG2";

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