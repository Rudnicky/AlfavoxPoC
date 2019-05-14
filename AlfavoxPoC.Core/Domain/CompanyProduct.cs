namespace AlfavoxPoC.Core.Domain
{
    public sealed class CompanyProduct : EntityBase
    {
        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
