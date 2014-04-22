using System.Collections.Generic;
using Desk.Entities;
using Desk.Response;

namespace Desk
{
    public interface ICompanyMapper
    {
        ListResponse<Company> All(int page = 1, int perPage = 50);
        Company Get(int companyId);
        Company Create(string name, IEnumerable<string> domains, Dictionary<string, string> customFields);
        Company Update(int companyId, string name, IEnumerable<string> domains, Dictionary<string, string> customFields);
    }
}