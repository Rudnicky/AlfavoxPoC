using AlfavoxPoC.Core.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlfavoxPoC.Core.ViewModels
{
    public sealed class AddLocationToCompanyViewModel
    {
        [Required]
        [Display(Name = "Company")]
        public int LocationId { get; set; }

        [Required]
        public int CompanyId { get; set; }

        public Company Company { get; set; }
        public List<SelectListItem> Locations { get; set; }

        public AddLocationToCompanyViewModel() { }

        public AddLocationToCompanyViewModel(Company company, IEnumerable<Location> locations)
        {
            Locations = new List<SelectListItem>();
            Company = company;

            foreach (var location in locations)
            {
                Locations.Add(new SelectListItem
                {
                    Value = location.LocationId.ToString(),
                    Text = location.City
                });
            }
        }
    }
}
