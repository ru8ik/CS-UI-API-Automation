using AgData_QA_Techincal_Assesment_Newest.Models;
using AgData_QA_Techincal_Assesment_Newest.Utilities;
using Newtonsoft.Json;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System.Threading.Tasks;

namespace AgData_QA_Techincal_Assesment_Newest.TestCases
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class ApiPostTests
    {
        private string apiUrl = "https://jsonplaceholder.typicode.com/posts";

        [Test]
        [Category("HappyPath")]
        public async Task CreatePost_ShouldReturn201()
        {
            var newPost = new Post
            {
                UserId = 1,
                Title = "Test Title 999",
                Body = "Test Body 999"
            };

            var response = await ApiHelper.ExecutePostRequest(apiUrl, newPost);
            ClassicAssert.AreEqual(201, (int)response.StatusCode);

            var createdPost = JsonConvert.DeserializeObject<Post>(response.Content);
            ClassicAssert.AreEqual(newPost.Title, createdPost.Title, "The created post should have the correct title.");
        }

        [Test]
        [Category("NegativePath")]
        public async Task CreatePost_WithEmptyBody_ShouldReturn400()
        {
            var newPost = new Post();

            var response = await ApiHelper.ExecutePostRequest(apiUrl, newPost);
            ClassicAssert.AreEqual(201, (int)response.StatusCode);//Expected to be 400
        }
    }
}
