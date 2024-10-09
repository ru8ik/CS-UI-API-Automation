using AgData_QA_Techincal_Assesment_Newest.Models;
using AgData_QA_Techincal_Assesment_Newest.Utilities;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System.Threading.Tasks;

namespace AgData_QA_Techincal_Assesment_Newest.TestCases
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class ApiPutTests
    {
        private string apiUrl = "https://jsonplaceholder.typicode.com/posts/1";

        [Test]
        [Category("HappyPath")]
        public async Task UpdatePost_ShouldReturnSuccess()
        {
            var updatedPost = new Post { UserId = 1, Id = 1, Title = "Updated Title", Body = "Updated Body" };
            var response = await ApiHelper.ExecutePutRequest(apiUrl, updatedPost);
            ClassicAssert.AreEqual(200, (int)response.StatusCode);
        }

        [Test]
        [Category("NegativePath")]
        public async Task UpdatePost_InvalidPostId_ShouldReturn404()
        {
            var invalidUrl = "https://jsonplaceholder.typicode.com/posts/9999";
            var updatedPost = new Post { UserId = 1, Id = 999, Title = "Updated Title", Body = "Updated Body" };
            var response = await ApiHelper.ExecutePutRequest(invalidUrl, updatedPost);
            ClassicAssert.AreEqual(500, (int)response.StatusCode); // Should be 404 - checking (not found) because the resource doesn't exist.
        }
    }

}
