namespace AlfavoxPoC.Core.Domain
{
    public sealed class CompanyLocation : EntityBase
    {
        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public int LocationId { get; set; }
        public Location Location { get; set; }
    }
}
