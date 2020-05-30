using FluentAssertions;
using RequestImplement.API_facade;
using RequestImplement.Helpers;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using TestDropboxApi.DataModels;

namespace API_testing.Steps
{
    [Binding]
    public class DeleteFileSteps
    {
        [Given(@"I have a path to the file to delete")]
        public void GivenIHaveAPathToTheFileToDelete(Table table)
        {
            var path = table.CreateInstance<Base>();
            ContextHelp.AddToContext<Base>("File_path", path);
            string[] header = { "Path", "Mode", "AutoRename", "Mute" };
            string[] row = { "/diagram.png", "add", "true", "false" };
            var t = new Table(header);
            t.AddRow(row);
            var upload = new GetFileListSteps();
            upload.GivenIHaveFileToUpload("diagram.png");
            upload.WhenIUploadTheFile(t);
        }
        
        [When(@"I send request to delete it")]
        public void WhenISendRequestToDeleteIt()
        {
            var file_path = ContextHelp.GetFromContext<Base>("File_path");
            var response = new DeleteFile_request(file_path).Send_request();
            response.EnsureSuccessful();
            ContextHelp.AddToContext("LastApiResponse", response);
        }
        
        [Then(@"I get info about deleted file")]
        public void ThenIGetInfoAboutDeletedFile()
        {
            var file_path = ContextHelp.GetFromContext<Base>("File_path");
            var apiResponse = ContextHelp.GetFromContext<ApiResponse>("LastApiResponse");
            var actual_file_info = apiResponse.Content<DeleteFileResponseDto>();
            apiResponse.StatusCode.Should().Be(200);
            actual_file_info.entry.PathLower.Should().Be(file_path.Path.ToString().ToLower());

        }
    }
}
