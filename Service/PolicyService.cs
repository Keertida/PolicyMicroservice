using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PolicyMicroservice.Models;
using PolicyMicroservice.Repository;

namespace PolicyMicroservice.Service
{
    public class PolicyService : IPolicyService
    {
        private readonly IPolicyRepo _policyRepo;
        private IConfiguration _configuration;

        public PolicyService(IConfiguration configuration,IPolicyRepo policyRepo)
        {
            _policyRepo = policyRepo;
            _configuration = configuration;
        }

        //public async Task<string> CreatePolicy(int PropertyId)
        //{
        //    return await _policyRepo.CreatePolicy(PropertyId);
        //}
        public bool CreatePolicy(createpolicy createPolicy)
        {
            return _policyRepo.CreatePolicy(createPolicy);
        }
        //public IEnumerable<createpolicy> GetPolicy()
        //{
        //    return _policyRepo.GetPolicy();
        //}



        public async Task<string> IssuePolicy(int PolicyId, string PaymentDetails)
        {
            return await _policyRepo.IssuePolicy(PolicyId, PaymentDetails);
        }

        public dynamic ViewPolicyById(int PolicyId)
        {
            return _policyRepo.ViewPolicyById(PolicyId);
        }
        public createpolicy Getconsumerpolicy(int PolicyId, int ConsumerId)
        {
            return _policyRepo.Getconsumerpolicy(PolicyId, ConsumerId);
        }

        public async Task<Quote> GetQuote(int BusinessValue, int PropertyValue)
        {
            return await _policyRepo.GetQuote(BusinessValue, PropertyValue);
        }


        public dynamic GetProperties()
        {
            return _policyRepo.GetProperties();
        }

        public dynamic GetPolicies()
        {
            return _policyRepo.GetPolicies();
        }
        public string GetQuotes(int PropertyValue, int BusinessValue, string PropertyType)
        {
            string uriConn = _configuration.GetValue<string>("ServiceURIs:Quotes");
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(uriConn);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Add("Accept", "application/json");
                    client.DefaultRequestHeaders.Add("ContentType", "application/json");

                    var httpResponse = client.GetAsync($"/api/Quotes/getQuotesForPolicy/{PropertyValue}/{BusinessValue}/{PropertyType}").Result;
                    var responseString = httpResponse.Content.ReadAsStringAsync().Result;

                    if (!httpResponse.IsSuccessStatusCode)
                    {
                        throw new Exception("Unable to reach [Consumer] microservice.");
                    }

                    string response = JsonConvert.DeserializeObject<string>(responseString);
                    return response;
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
