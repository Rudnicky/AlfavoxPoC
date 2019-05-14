using AlfavoxPoC.Core.Domain;
using System.Collections.Generic;

namespace AlfavoxPoC.Core.ViewModels
{
    public sealed class ViewCompanyViewModel
    {
        public Company Company { get; set; }
        public IList<CompanyEmployee> CompanyEmployees { get; set; }
        public IList<CompanyLocation> CompanyLocations { get; set; }
    }
}
