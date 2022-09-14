using PolicyMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolicyMicroservice.Service
{
    public interface IPolicyService
    {
        bool CreatePolicy(createpolicy createPolicy);
        //public Task<string> CreatePolicy(int PropertyId);

        public Task<string> IssuePolicy(int PolicyId, string PaymentDetails);
        //IEnumerable<Consumer> GetConsumers();
        //IEnumerable<createpolicy> GetPolicy();

        public dynamic ViewPolicyById(int PolicyId);

        public Task<Quote> GetQuote(int BusinessValue, int PropertyValue);
        string GetQuotes(int PropertyValue, int BusinessValue, string PropertyType);
        createpolicy Getconsumerpolicy(int PolicyId, int ConsumerId);

        public dynamic GetProperties();

        public dynamic GetPolicies();
    }
}
