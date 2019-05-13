using System.Collections.Generic;

namespace AlfavoxPoC.Core.Domain
{
    public sealed class Company : EntityBase
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Location> Locations { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
    }
}
