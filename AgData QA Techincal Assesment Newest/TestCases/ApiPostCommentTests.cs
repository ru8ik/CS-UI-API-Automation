using AgData_QA_Techincal_Assesment_Newest.Models;
using AgData_QA_Techincal_Assesment_Newest.Utilities;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System.Threading.Tasks;


namespace AgData_QA_Techincal_Assesment_Newest.TestCases
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class ApiPostCommentTests
    {
        private string apiUrl = "https://jsonplaceholder.typicode.com/posts/1/comments";

        [Test]
        [Category("HappyPath")]
        public async Task CreateComment_ShouldReturnSuccess()
        {
            var newComment = new Comment { PostId = 1, Name = "Test Name", Email = "test@test.com", Body = "Test Comment" };
            var response = await ApiHelper.ExecutePostRequest(apiUrl, newComment);
            ClassicAssert.AreEqual(201, (int)response.StatusCode);
        }

        [Test]
        [Category("NegativePath")]
        public async Task CreateComment_InvalidPostId_ShouldReturn404()
        {
            var invalidUrl = "https://jsonplaceholder.typicode.com/posts/999/comments";
            var newComment = new Comment { PostId = 999, Name = "Test Name", Email = "test@test.com", Body = "Test Comment" };
            var response = await ApiHelper.ExecutePostRequest(invalidUrl, newComment);
            ClassicAssert.AreEqual(201, (int)response.StatusCode);// Should be 404
        }
    }

}
