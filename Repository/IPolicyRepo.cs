using PolicyMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolicyMicroservice.Repository
{
    public interface IPolicyRepo
    {
        //public Task<string> CreatePolicy(int PropertyId);
        bool CreatePolicy(createpolicy createPolicy);
        //IEnumerable<createpolicy> GetPolicy(int PolicyId);
        createpolicy Getconsumerpolicy(int PolicyId, int ConsumerId);

        public Task<string> IssuePolicy(int PolicyId, string PaymentDetails);

        public dynamic ViewPolicyById(int PolicyId);

        public Task<Quote> GetQuote(int BusinessValue, int PropertyValue);

        public dynamic GetProperties();

        public dynamic GetPolicies();

    }
}
