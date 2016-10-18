using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProjectWpfAppExpVersion
{
    class RESTHandler
    {
        private string url;
        private IRestResponse response;
        private RestRequest request;

        public RESTHandler()
        {
            url = "";
        }

        public RESTHandler(string lurl)
        {
            url = lurl;
            request = new RestRequest();
        }

        public void AddParameter(string name, string value)
        {
            if (request != null)
            {
                request.AddParameter(name, value);
            }
        }

        public Response.RootObject ExecuteCurrentRequest()
        {
            var client = new RestClient(url);

            response = client.Execute(request);

            Response.RootObject objRoot = new Response.RootObject();
            objRoot = JsonConvert.DeserializeObject<Response.RootObject>(response.Content);

            return objRoot;
        }

        public async Task<Response.RootObject> ExecuteCurrentRequestAsync()
        {
            var client = new RestClient(url);
            var request = new RestRequest();

            response = await client.ExecuteTaskAsync(request);

            Response.RootObject objRoot = new Response.RootObject();
            objRoot = JsonConvert.DeserializeObject<Response.RootObject>(response.Content);

            return objRoot;
        }
    }
}
