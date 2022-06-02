using System;
using NUnit.Framework;
using RestSharp;


namespace WebAPI
{
    public class Tests
    {

        const string token = "sl.BIylfI99BsJ5gZ1GL0oX-ffcbdWi2Vdkpy4gvz6Et8hIZjKVy-NX__BXKTzNN-lsBIaJPcIEcB8PjS5bBjZA1sGclC2WTOTCqckcDZMYE5lqKKCz67NoFm2fxz6z9HtIO6RbyjDhMPA";
        const string upload = "https://content.dropboxapi.com/2/files/upload";
        const string metadata = "https://api.dropboxapi.com/2/files/get_metadata";
        const string delete = "https://api.dropboxapi.com/2/files/delete_v2";

        
        [Test, Order(1)]
        public void TestUpload()
        {
            var client = new RestClient(upload);
            var request = new RestSharp.RestRequest(Method.POST);
            request.AddHeader("Dropbox-API-Arg", "{\"autorename\":false,\"mode\":\"add\",\"mute\":false,\"path\":\"/TextFile1.txt\",\"strict_conflict\":false}");
            request.AddHeader("Content-Type", "application/octet-stream");
            request.AddHeader("Authorization", "Bearer " + token);
            var body1 = @"Text File 1.";
            request.AddParameter("application/octet-stream", body1, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            Console.WriteLine(response.Content);

            Assert.IsTrue(response.IsSuccessful);
        }

        [Test, Order(2)]
        public void TestGetMetadata()
        {
            var client = new RestClient(metadata);
            var request = new RestSharp.RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer "+ token);
            var body = "{\"include_deleted\":false,\"include_has_explicit_shared_members\":false,\"include_media_info\":false,\"path\":\"/TextFile1.txt\"}";
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            Console.WriteLine(response.Content);

            Assert.IsTrue(response.IsSuccessful);
        }

        [Test, Order(3)]
        public void TestDelete()
        {
            var client = new RestClient(delete);
            var request = new RestSharp.RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + token);
            var body = "{\"path\":\"/TextFile1.txt\"}";
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            Console.WriteLine(response.Content);

            Assert.IsTrue(response.IsSuccessful);
        }

    }
}