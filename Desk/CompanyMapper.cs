using System.Collections.Generic;
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
            var request = new RestRequest()
            {
                Resource = "companies?page={page}&per_page={per_page}",
                Method = Method.GET,
                RequestFormat = DataFormat.Json
            };

            request.AddUrlSegment("page", page.ToString());
            request.AddUrlSegment("per_page", perPage.ToString());
            var response = _api.Call(request);

            return new ListResponse<Company>(response);
        }

        public Company Get(int companyId)
        {
            if (companyId < 1) { return null; }

            var request = new RestRequest()
            {
                Resource = "companies/{id}",
                Method = Method.GET,
                RequestFormat = DataFormat.Json
            };

            request.AddUrlSegment("id", companyId.ToString());
            var response = _api.Call(request);

            return new Company(response.Content);
        }

        public Company Create(string name, IEnumerable<string> domains, Dictionary<string, string> customFields)
        {
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

            var response = _api.Call(request);

            return new Company(response.Content);
        }
    }
}
