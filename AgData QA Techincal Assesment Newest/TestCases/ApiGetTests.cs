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
    public class ApiGetTests
    {
        private readonly string apiUrl = "https://jsonplaceholder.typicode.com/posts";

        [Test]
        [Category("HappyPath")]
        public async Task GetPosts_ShouldReturnSuccess()
        {
            var response = await ApiHelper.ExecuteGetRequest(apiUrl);
            ClassicAssert.AreEqual(200, (int)response.StatusCode);

            var posts = JsonConvert.DeserializeObject<List<Post>>(response.Content);
            ClassicAssert.IsNotNull(posts, "list should not be null.");
            ClassicAssert.IsTrue(posts.Count > 0, "list should contain at least one post.");
        }

        [Test]
        [Category("NegativePath")]
        public async Task GetPosts_InvalidUrl_ShouldReturn404()
        {
            var invalidUrl = apiUrl + "TEST";
            var response = await ApiHelper.ExecuteGetRequest(invalidUrl);
            ClassicAssert.AreEqual(404, (int)response.StatusCode, "Should Return 404.");
        }
    }
}
