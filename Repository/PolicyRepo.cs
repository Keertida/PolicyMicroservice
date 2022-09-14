using Microsoft.EntityFrameworkCore;
using PolicyMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolicyMicroservice.Repository
{
    public class PolicyRepo : IPolicyRepo
    {
        private readonly InsureityPortalDatabaseContext context;

        public PolicyRepo(InsureityPortalDatabaseContext policyDBContext)
        {
            context = policyDBContext;
        }


        public bool CreatePolicy(createpolicy createPolicy)
        {
            var id = context.createpolicies.Count();
            createpolicy consumerPolicy = new createpolicy()
            {

                ConsumerId = createPolicy.ConsumerId,
                BusinessId = createPolicy.BusinessId,
                AcceptedQuotes = createPolicy.AcceptedQuotes,
                Name = createPolicy.Name,
                PolicyId = createPolicy.PolicyId,
                AgentId = createPolicy.AgentId,

                PolicyStatus = "Initiated",
            };

            context.createpolicies.Add(consumerPolicy);
            context.SaveChanges();
            return true;
        }
        //public IEnumerable<createpolicy> GetPolicy(int PolicyId)
        //{
        //    return context.createpolicies.FirstOrDefault(x => x.PolicyId == PolicyId);
        //}
        public createpolicy Getconsumerpolicy(int PolicyId, int ConsumerId)
        {
            return context.createpolicies.FirstOrDefault(x => x.PolicyId == PolicyId);
        }


        public virtual async Task<string> IssuePolicy(int PolicyId, string PaymentDetails)
        {
            try
            {
                if (PaymentDetails == "Paid")
                {
                    createpolicy policy = context.createpolicies.SingleOrDefault(p => p.PolicyId == PolicyId);
                    if (policy == null)
                    {
                        return "No Policy exists with ID " + PolicyId + ".";
                    }
                    if (policy.PolicyStatus == "Issued")
                    {
                        return "Policy has already been Issued.";
                    }
                    policy.PolicyStatus = "Issued";
                    await context.SaveChangesAsync();
                    return "Policy has been " + policy.PolicyStatus + " for Policy ID " + policy.PolicyId + ".";
                }
                return "No Payment was made. Hence, Policy was not Issued.";
            }
            catch
            {
                return "Policy was not Issued.";
            }
        }

        public virtual async Task<Quote> GetQuote(int BusinessValue, int PropertyValue)
        {
            List<Quote> quotes = context.Quotes.ToList();
            if (BusinessValue >= 0 && BusinessValue <= 10 && PropertyValue >= 0 && PropertyValue <= 10)
            {
                foreach (Quote q in quotes)
                {
                    if (BusinessValue >= q.BusinesssValueFrom && BusinessValue <= q.BusinesssValueTo &&
                        PropertyValue >= q.PropertyValueFrom && PropertyValue <= q.PropertyValueTo)
                    {
                        return await context.Quotes.FindAsync(q.QuoteId);
                    }
                }
            }
            return null;
        }


        public virtual dynamic ViewPolicyById(int PolicyId)
        {
            try
            {
                var policy = context.ConsumerPolicies
                    .Include(c => c.Property).Include(c => c.PolicyMaster).Include(c => c.Quote)
                    .Where(cp => cp.PolicyId == PolicyId)
                    .Select(cp => new
                    {
                        PolicyId = cp.PolicyId,
                        BuildingType = cp.Property.BuildingType,
                        PolicyStatus = cp.PolicyStatus,
                        PropertyId = cp.PropertyId,
                        PropertyType = cp.PolicyMaster.PropertyType,
                        PropertyValue = cp.Property.PropertyMaster.PropertyValue,
                        BusinessValue = cp.Property.Business.BusinessMaster.BusinessValue,
                        QuoteValue = cp.Quote.QuoteValue,
                        ConsumerId = cp.Property.Business.ConsumerID,
                        ConsumerName = cp.Property.Business.Consumer.ConsumerName
                    }).FirstOrDefault();
                return policy;
            }
            catch
            {
                return null;
            }
        }

        public virtual dynamic GetProperties()
        {
            try
            {
                var properties = context.Properties
                    .Include(p => p.Business).Include(p => p.PropertyMaster)
                    .Select(p => new
                    {
                        PropertyId = p.PropertyId,
                        BuildingType = p.BuildingType,
                        BuildingAge = p.BuildingAge,
                        BuildingStoreys = p.BuildingStoreys,
                        PropertyValue = p.PropertyMaster.PropertyValue,
                        BusinessId = p.BusinessId,
                        BusinessValue = p.Business.BusinessMaster.BusinessValue,
                        ConsumerId = p.Business.ConsumerID,
                        ConsumerName = p.Business.Consumer.ConsumerName
                    }).ToList();
                return properties;
            }
            catch
            {
                return null;
            }
        }

        public virtual dynamic GetPolicies()
        {
            try
            {
                var policies = context.ConsumerPolicies
                    .Include(c => c.Property).Include(c => c.PolicyMaster).Include(c => c.Quote)
                    .Select(cp => new
                    {
                        PolicyId = cp.PolicyId,
                        BuildingType = cp.Property.BuildingType,
                        PolicyStatus = cp.PolicyStatus,
                        PropertyId = cp.PropertyId,
                        PropertyType = cp.PolicyMaster.PropertyType,
                        PropertyValue = cp.Property.PropertyMaster.PropertyValue,
                        BusinessValue = cp.Property.Business.BusinessMaster.BusinessValue,
                        QuoteValue = cp.Quote.QuoteValue,
                        ConsumerId = cp.Property.Business.ConsumerID,
                        ConsumerName = cp.Property.Business.Consumer.ConsumerName
                    }).ToList();
                return policies;
            }
            catch
            {
                return null;
            }

        }

    }
}
