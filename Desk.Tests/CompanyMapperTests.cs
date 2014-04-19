using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Desk.Entities;
using Desk.Request;
using NSubstitute;
using NUnit.Framework;
using RestSharp;

namespace Desk.Tests
{
    [TestFixture]
    public class CompanyMapperTests
    {
        private ICompanyMapper _mapper;
        private IDeskApi _connection;
        private IRestResponse _getResponse;

        [SetUp]
        public void Setup()
        {
            _getResponse = Substitute.For<IRestResponse>();

            _connection = Substitute.For<IDeskApi>();
            _connection.Call(Arg.Any<string>(), Method.GET).Returns(_getResponse);
            _connection.Call(Arg.Any<IRestRequest>()).Returns(_getResponse);

            _mapper = new CompanyMapper(_connection);
        }

        [Test]
        public void Get_ShouldReturnNullWithIdLessThanOne()
        {
            var actual = _mapper.Get(0);
            Assert.That(actual, Is.Null);
        }

        [Test]
        public void Get_ShouldReturnPopulatedCompanyWhenSuccessful()
        {
            var companyJsonData = TestData.CompanyTestData.GetCompanyJson;
            var expected = new Company(companyJsonData);
            _getResponse.Content.Returns(companyJsonData);

            var actual = _mapper.Get(1);

            Assert.That(actual.Name, Is.EqualTo(expected.Name));
            Assert.That(actual.Domains, Is.EquivalentTo(expected.Domains));
            Assert.That(actual.CustomFields, Is.EquivalentTo(expected.CustomFields));
        }

        [Test]
        public void Create_ShouldReturnPopulatedCompanyWhenSuccessful()
        {
            var companyJsonData = TestData.CompanyTestData.GetCompanyJson;
            var expected = new Company(companyJsonData);
            _getResponse.Content.Returns(companyJsonData);

            var actual = _mapper.Create(expected.Name, expected.Domains, expected.CustomFields);

            Assert.That(actual.Name, Is.EqualTo(expected.Name));
            Assert.That(actual.Domains, Is.EquivalentTo(expected.Domains));
            Assert.That(actual.CustomFields, Is.EquivalentTo(expected.CustomFields));
        }
    }
}
