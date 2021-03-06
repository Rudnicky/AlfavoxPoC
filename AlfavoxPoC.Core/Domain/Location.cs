﻿using System.ComponentModel.DataAnnotations;

namespace AlfavoxPoC.Core.Domain
{
    public sealed class Location : EntityBase
    {
        [Key]
        public int LocationId { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostCode { get; set; }
        public Company Company { get; set; }
    }
}
