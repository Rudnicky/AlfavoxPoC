namespace AlfavoxPoC.Core.Domain
{
    public sealed class CompanyEmployee : EntityBase
    {
        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
