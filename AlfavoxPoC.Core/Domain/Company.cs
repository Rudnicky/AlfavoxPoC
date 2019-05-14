using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlfavoxPoC.Core.Domain
{
    public sealed class Company : EntityBase
    {
        [Key]
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public IEnumerable<CompanyEmployee> Employees { get; set; }
        public IEnumerable<CompanyLocation> Locations { get; set; }
        public IEnumerable<CompanyProduct> Products { get; set; }
    }
}
