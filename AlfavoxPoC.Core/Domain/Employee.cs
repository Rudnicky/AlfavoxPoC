namespace AlfavoxPoC.Core.Domain
{
    public class Employee : EntityBase
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public Company Company { get; set; }
    }
}
