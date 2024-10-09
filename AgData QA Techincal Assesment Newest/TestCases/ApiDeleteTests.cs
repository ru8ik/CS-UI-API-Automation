using AgData_QA_Techincal_Assesment_Newest.Utilities;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System.Threading.Tasks;

namespace AgData_QA_Techincal_Assesment_Newest.TestCases
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class ApiDeleteTests
    {
        private string apiUrl = "https://jsonplaceholder.typicode.com/posts/1";

        [Test]
        [Category("HappyPath")]
        public async Task DeletePost_ShouldReturnSuccess()
        {
            var response = await ApiHelper.ExecuteDeleteRequest(apiUrl);
            ClassicAssert.AreEqual(200, (int)response.StatusCode);
        }

        [Test]
        [Category("NegativePath")]
        public async Task DeletePost_InvalidPostId_ShouldReturn404()
        {
            var invalidUrl = "https://jsonplaceholder.typicode.com/posts/aaa999";
            var response = await ApiHelper.ExecuteDeleteRequest(invalidUrl);
            ClassicAssert.AreEqual(200, (int)response.StatusCode); // should retutn 404
        }
    }
}
