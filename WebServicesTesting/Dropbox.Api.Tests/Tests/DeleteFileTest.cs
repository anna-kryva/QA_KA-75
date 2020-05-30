using System;
using System.Reflection;
using System.IO;
using System.Threading;
using NUnit.Framework;
using FluentAssertions;
using TechTalk.SpecFlow;
using TestDropboxApi.ApiFacade;
using TestDropboxApi.DataModels;
using TestDropboxApi.Extensions;
using TestDropboxApi.Helpers;

namespace Dropbox.Api.Tests.Tests
{
    [TestFixture]
    public class DeleteFileTest //Инкапсуляция функций
    {
        [TestCase("test.jpg")]
        public void DeleteTest(string fileName)
        {
            var filePath = "/first/" + fileName;
            UploadFile("/first/", fileName);
            var response = DeleteRequest(filePath);
            Assert.IsNotNull(response);
        }

        private void UploadFile(string fileName)
        {
            var filePath = GetFilePath(fileName);
            var file = File.ReadAllBytes(filePath);
            var uploadFile = new UploadFileDto();
            uploadFile.Path = "/" + fileName;
            var response = new DropboxApiContent().UploadFile(uploadFile, file);
            response.EnsureSuccessful();
        }
        private void UploadFile(string folder, string fileName) //Статический полиморфизм
        {
            var filePath = GetFilePath(fileName);
            var file = File.ReadAllBytes(filePath);
            var uploadFile = new UploadFileDto();
            uploadFile.Path = folder + fileName;
            var response = new DropboxApiContent().UploadFile(uploadFile, file);
            response.EnsureSuccessful();
        }
        private string GetFilePath(string fileName)
        {
            string codeBase = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase)
                              + Path.DirectorySeparatorChar
                              + ConfigurationHelper.DefaultFilePath;
            var uri = new UriBuilder(codeBase).Uri.Append(fileName);
            string fullPath = Path.GetFullPath(Uri.UnescapeDataString(uri.AbsolutePath));
            return fullPath;
        }

        private FileResponseDto DeleteRequest(string filePath)
        {
            var response = new DropboxApi().DeleteFile(filePath);
            response.EnsureSuccessful();
            var fileInfo = response.Content<FileResponseDto>();
            return fileInfo;
        }

    }
}
