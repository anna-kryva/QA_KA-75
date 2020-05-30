using NUnit.Framework;
using TestDropboxApi.ApiFacade;
using TestDropboxApi.DataModels;

namespace Dropbox.Api.Tests.Tests
{
    [TestFixture]
    public class GetFileMetadata //Инкапсуляция функций
    {
        [TestCase(new object[] { "first", "fireman.jpg" })]
        [TestCase(new object[] { "second", "fireman.jpg" })]
        public void GetMetadataTest(object[] value)
        {
            var response = GetMetadataRequest(PathConverter(value));
            Assert.IsNotNull(response);
            var fileName = response.Name.ToString();
            Assert.AreEqual(fileName, value[1]);
        }

        private FileResponseDto GetMetadataRequest(string filePath)
        {
            var response = new DropboxApi().GetFileMetadata(filePath);
            response.EnsureSuccessful();
            var fileInfo = response.Content<FileResponseDto>();
            return fileInfo;
        }

        private string PathConverter(object[] arr)
        {
            string path = "";
            for(int i = 0; i < arr.Length; i++)
            {
                path += "/";
                path += arr[i];
            }
            return path;
        }

    }
}
