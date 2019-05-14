using AlfavoxPoC.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace AlfavoxPoC.Core.Domain
{
    public sealed class Product : EntityBase
    {
        [Key]
        public int ProductId { get; set; }
        public string Title { get; set; }
        public ProductType Type { get; set; }
        public string BriefContent { get; set; }
        public Company Company { get; set; }
    }
}
