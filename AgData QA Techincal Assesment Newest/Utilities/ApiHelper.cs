using System; 
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;


namespace AgData_QA_Techincal_Assesment_Newest.Utilities
{
    public static class ApiHelper
    {
        private static RestClient client = new RestClient();

        // GET request helper with Console OUtput 
        public static async Task<RestResponse> ExecuteGetRequest(string url)
        {
            Console.WriteLine($"GET Request to {url}");  // Log the GET request URL

            var request = new RestRequest(url, Method.Get); // Create a GET request
            var response = await client.ExecuteAsync(request);  // Execute the request

            // Log the response status and content
            Console.WriteLine($"Response Status: {response.StatusCode}");
            Console.WriteLine($"Response Body: {response.Content}");

            return response;  // Return the response to be used in the test cases
        }


        // POST request helper with Console OUtput 
        public static async Task<RestResponse> ExecutePostRequest<T>(string url, T body)
        {
            Console.WriteLine($"POST Request to {url} with body: {JsonConvert.SerializeObject(body)}");
            var request = new RestRequest(url, Method.Post);
            request.AddJsonBody(JsonConvert.SerializeObject(body));

            var response = await client.ExecuteAsync(request);
            Console.WriteLine($"Response: {response.StatusCode}, {response.Content}");

            return response;
        }


        // PUT request helper with Console OUtput 
        public static async Task<RestResponse> ExecutePutRequest<T>(string url, T body)
        {

            Console.WriteLine($"PUT Request to {url} with body: {JsonConvert.SerializeObject(body)}");
            var request = new RestRequest(url, Method.Put);
            request.AddJsonBody(JsonConvert.SerializeObject(body));

            var response = await client.ExecuteAsync(request);
            Console.WriteLine($"Response: {response.StatusCode}, {response.Content}");

            return response;

        }

        // DELETE request helper
        public static async Task<RestResponse> ExecuteDeleteRequest(string url)
        {

            Console.WriteLine($"DELETE Request to {url}");  // Log the DELETE request URL

            var request = new RestRequest(url, Method.Delete); // Create a DELETE request
            var response = await client.ExecuteAsync(request);  // Execute the request

            // Log the response status and content
            Console.WriteLine($"Response Status: {response.StatusCode}");
            Console.WriteLine($"Response Body: {response.Content}");

            return response;  // Return the response to be used in the test cases
        }



    }
}
