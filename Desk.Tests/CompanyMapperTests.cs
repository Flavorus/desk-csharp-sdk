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

//        [Test]
//        public void GetTopics_ShouldAccessCorrectResourceWithoutParameters()
//        {
//            _mapper.GetTopics(GetTopicsParameters.None);
//
//            _connection.Received().Call("topics.json", Method.GET);
//        }
//
//        [Test]
//        [TestCase(10, 20)]
//        [TestCase(20, 30)]
//        public void GetTopics_ShouldAccessCorrectResourceWithParameters(int count, int page)
//        {
//            _mapper.GetTopics(new GetTopicsParameters { Count = count, Page = page });
//
//            _connection.Received().Call("topics.json?count=" + count + "&page=" + page, Method.GET);
//        }
//
//        [Test]
//        public void GetTopics_ShouldReturnRawResponse()
//        {
//            var result = _mapper.GetTopics(GetTopicsParameters.None);
//
//            Assert.That(result, Is.EqualTo(_getResponse));
//        }
//
//        [Test]
//        public void GetTopicsMapped_ShouldAccessCorrectResourceWithoutParameters()
//        {
//            _mapper.GetTopicsMapped(GetTopicsParameters.None);
//
//            _connection.Received().Call("topics.json", Method.GET);
//        }
//
//        [Test]
//        [TestCase(10, 20)]
//        [TestCase(20, 30)]
//        public void GetTopicsMapped_ShouldAccessCorrectResourceWithParameters(int count, int page)
//        {
//            _mapper.GetTopicsMapped(new GetTopicsParameters { Count = count, Page = page });
//
//            _connection.Received().Call("topics.json?count=" + count + "&page=" + page, Method.GET);
//        }
//
//        [Test]
//        public void GetTopics_ShouldReturnMappedResponse()
//        {
//            var result = _mapper.GetTopicsMapped(GetTopicsParameters.None);
//
//            Assert.That(result, Is.TypeOf(typeof(GetTopicsResponse)));
//        }
//
//        [Test]
//        public void VerifyConnection_ShouldAccessCorrectResource()
//        {
//            _mapper.VerifyConnection();
//
//            _connection.Received().Call("account/verify_credentials.json", Method.GET);
//        }
//
//        [Test]
//        public void VerifyConnection_ShouldReturnRawResponse()
//        {
//            var result = _mapper.VerifyConnection();
//
//            Assert.That(result, Is.EqualTo(_getResponse));
//        }
    }

}
