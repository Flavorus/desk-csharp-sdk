namespace Desk.TestData
{
    /// <summary>
    /// This class represents the data that is received for
    /// a certain Company.
    /// </summary>
    /// <remarks>
    /// Link:       http://github.com/danielsaidi/desk-csharp-sdk
    /// </remarks>
    public static class CompanyTestData
    {
        public static string GetCompanyJson
        {
            get
            {
                return @"
                {
                    'id':1,
                    'name':'A Test Company',
                    'domains':['atestcompany.com', 'atestcompany.org'],
                    'created_at':'2014-04-01T18:14:18Z',
                    'updated_at':'2014-04-01T18:14:18Z',
                    'custom_fields':{'field1':'value1', 'field2':'value2'}
                }".Replace("'", "\"");
            }
        }

        public static string GetCompaniesJson
        {
            get
            {
                return @"
                {
                    'id':1,
                    'name':'A Test Company',
                    'domains':['atestcompany.com', 'atestcompany.org'],
                    'created_at':'2014-04-01T18:14:18Z',
                    'updated_at':'2014-04-01T18:14:18Z',
                    'custom_fields':{'field1':'value1', 'field2':'value2'}
                }".Replace("'", "\"");
            }
        }
    }
}
