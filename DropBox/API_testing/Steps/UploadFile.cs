using System;
using System.IO;
using System.Reflection;
using System.Configuration;
using TechTalk.SpecFlow;
using FluentAssertions;
using RequestImplement.Helpers;
using RequestImplement.Extensions;
using RequestImplement.DataModels;
using System.Text.Json;
using RequestImplement.Requests;
using TestDropboxApi.DataModels;
using TechTalk.SpecFlow.Assist;

namespace API_testing.Steps
{
    [Binding]
    public class GetFileListSteps
    {
        [Given(@"I have '(.*)' file to upload")]
        public void GivenIHaveFileToUpload(string fileName)
        {
            var filePath = GetFilePath(fileName);
            File.Exists(filePath)
                .Should()
                .BeTrue($"expected {fileName} to exists with test fata files inside the {filePath}");

            ContextHelp.AddToContext("FilePath", filePath);
        }
        
        [When(@"I upload the file")]
        public void WhenIUploadTheFile(Table table)
        {
            var uploadFile = table.CreateInstance<UploadFileDto>();
            var filePath = ContextHelp.GetFromContext<string>("FilePath");
            var file = File.ReadAllBytes(filePath);
            var response = new UploadFile_request(uploadFile, file).Send_request();
            response.EnsureSuccessful();
            ContextHelp.AddToContext("LastApiResponse", response);
        }
        
        [Then(@"I should be able to get file info")]
        public void ThenIShouldBeAbleToGetFileInfo(Table table)
        {
            var fileInfo = table.CreateInstance<FileResponseDto>();
            var apiResponse = ContextHelp.GetFromContext<ApiResponse>("LastApiResponse");
            var actualFileInfo = apiResponse.Content<FileResponseDto>();

            actualFileInfo.Should().BeEquivalentTo(fileInfo, options => options.Including(f => f.Name));
        }
        private string GetFilePath(string fileName)
        {
            string codeBase = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase)
                              + Path.DirectorySeparatorChar
                              + ConfigParams.defaultFilePath;
            var uri = new UriBuilder(codeBase).Uri.Append(fileName);
            string fullPath = Path.GetFullPath(Uri.UnescapeDataString(uri.AbsolutePath));

            ScenarioContext.Current["DefaultFilePath"] = fullPath;
            return fullPath;
        }

    }
}
