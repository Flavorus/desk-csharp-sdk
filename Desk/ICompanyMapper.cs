using Desk.Entities;
using Desk.Response;

namespace Desk
{
    public interface ICompanyMapper
    {
        ListResponse<Company> All(int page = 1, int perPage = 50);
        Company Get(int companyId);
    }
}