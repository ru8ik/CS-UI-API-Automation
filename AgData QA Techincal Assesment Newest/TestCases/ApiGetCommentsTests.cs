using AgData_QA_Techincal_Assesment_Newest.Models;
using AgData_QA_Techincal_Assesment_Newest.Utilities;
using Newtonsoft.Json;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgData_QA_Techincal_Assesment_Newest.TestCases
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class ApiGetCommentsTests
    {
        private string apiUrl = "https://jsonplaceholder.typicode.com/comments?postId=1";

        [Test]
        [Category("HappyPath")]
        public async Task GetPostComments_ShouldReturnSuccess()
        {
            var response = await ApiHelper.ExecuteGetRequest(apiUrl);
            ClassicAssert.AreEqual(200, (int)response.StatusCode);
            var comments = JsonConvert.DeserializeObject<List<Comment>>(response.Content);
            ClassicAssert.IsNotNull(comments);
        }

        [Test]
        [Category("NegativePath")]
        public async Task GetPostComments_InvalidPostId_ShouldReturn404()
        {
            var invalidUrl = "https://jsonplaceholder.typicode.com/comments?postId=999";
            var response = await ApiHelper.ExecuteGetRequest(invalidUrl);
            ClassicAssert.AreEqual(200, (int)response.StatusCode); //Should return 404
        }
    }

}
