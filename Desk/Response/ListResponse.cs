using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Desk.Entities;
using RestSharp;

namespace Desk.Response
{
    public class ListResponse<T> where T : EntityBase
    {
        public List<Link> Links { get; private set; }

        public int TotalEntries { get; private set; }

        public int Page { get; private set; }

        public ListResponse(IRestResponse response)
        {
            
        }

        private void ParseResponse(IRestResponse response)
        {
               
        }
    }

    public class Link
    {
        public string Name { get; set; }

        public string HRef { get; set; }

        public string Class { get; set; }
    }
}
