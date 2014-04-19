using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using Desk.Entities;
using Desk.Response;
using Newtonsoft.Json;
using RestSharp;

namespace Desk
{
    public class CompanyMapper : ICompanyMapper
    {
        private readonly IDeskApi _api;

        public CompanyMapper(IDeskApi api)
        {
            _api = api;
        }

        public ListResponse<Company> All(int page = 1, int perPage = 50)
        {
            return new ListResponse<Company>(List(page, perPage));
        }

        public Company Get(int companyId)
        {
            if (companyId < 1) { return null; }

            var response = Show(companyId);
            return new Company(response.Content);
        }

        public Company Create(string name, IEnumerable<string> domains, Dictionary<string, string> customFields)
        {
            //Not the place for this code, but will do temporarily.
            var restClient = new RestClient()
            {
                BaseUrl = "https://assetbook1.desk.com/api/v2",
                Authenticator = new HttpBasicAuthenticator("miguel@zakharia.me", "da5yHaRq9Bk4rpl")
            };

            var request = new RestRequest()
            {
                Resource = "companies",
                Method = Method.POST,
                RequestFormat = DataFormat.Json
            };

            request.AddParameter(new Parameter()
            {
                Name = "",
                Type = ParameterType.RequestBody,
                Value = JsonConvert.SerializeObject(new
                {
                    name,
                    domains,
                    custom_fields = customFields
                })
            });

            var response = restClient.Execute(request);

            return new Company(response.Content);
        }

        private IRestResponse List(int page = 1, int perPage = 50)
        {
            return _api.Call(string.Format("companies?page={0}&per_page={1}", page, perPage), Method.GET);
        }

        private IRestResponse Show(int companyId)
        {
            return _api.Call("companies/" + companyId, Method.GET);
        }
    }
}
