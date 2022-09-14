using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PolicyMicroservice.Models
{
    public class createpolicy
    {
        [Key]
        public int PolicyId { get; set; }
        public int ConsumerId { get; set; }
        public string Name { get; set; }
        public int BusinessId { get; set; }
        public int AgentId { get; set; }
        public int AcceptedQuotes { get; set; }
        public string PolicyStatus { get; set; }
    }
}
