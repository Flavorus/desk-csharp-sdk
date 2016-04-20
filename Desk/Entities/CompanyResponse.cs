using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Desk.Response;
using RestSharp;

namespace Desk.Entities
{
    public class CompanyResponse
    {
        public List<Link> Links { get; set; }
        public Company Company { get; set; }

        public CompanyResponse(IRestResponse response)
        {
            
        }
    }
}
