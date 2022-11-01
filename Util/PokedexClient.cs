using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PokedexCharp.Util
{
    public class PokedexClient
    {
        readonly RestClient _client;

        public PokedexClient()
        {
            _client = new RestClient("https://pokeapi.co/api/v2/pokemon/");
        }

        public string GetRequest()
        {
            string result = "";
            var request = new RestRequest();
            RestRequest getRequest = new RestRequest("", Method.Get);
            var response = _client.Execute(getRequest);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result = response.Content;
            }
            else
            {
                result = null;
            }
            return result;
        }

        public string GetRequestByNameOrId(string nameOrId)
        {
            string result = "";
            var request = new RestRequest();
            RestRequest getRequest = new RestRequest(nameOrId, Method.Get);
            var response = _client.Execute(getRequest);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result = response.Content;
            }
            else
            {
                result = null;
            }
            return result;
        }

    }
}
