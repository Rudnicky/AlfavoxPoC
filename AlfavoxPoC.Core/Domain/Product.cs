using AlfavoxPoC.Core.Enums;

namespace AlfavoxPoC.Core.Domain
{
    public sealed class Product : EntityBase
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
        public ProductType Type { get; set; }
        public string BriefContent { get; set; }
        public Company Company { get; set; }
    }
}
