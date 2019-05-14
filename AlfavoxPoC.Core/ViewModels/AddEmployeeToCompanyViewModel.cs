using AlfavoxPoC.Core.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlfavoxPoC.Core.ViewModels
{
    public sealed class AddEmployeeToCompanyViewModel
    {
        [Required]
        [Display(Name = "Company")]
        public int EmployeeId { get; set; }

        [Required]
        public int CompanyId { get; set; }

        public Company Company { get; set; }
        public List<SelectListItem> Employees { get; set; }

        public AddEmployeeToCompanyViewModel() { }

        public AddEmployeeToCompanyViewModel(Company company, IEnumerable<Employee> employees)
        {
            Employees = new List<SelectListItem>();
            Company = company;

            foreach (var employee in employees)
            {
                Employees.Add(new SelectListItem
                {
                    Value = employee.EmployeeId.ToString(),
                    Text = employee.LastName
                });
            }
        }
    }
}
