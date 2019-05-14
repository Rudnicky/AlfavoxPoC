using AlfavoxPoC.Core.Domain;
using AlfavoxPoC.Core.Interfaces;
using AlfavoxPoC.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AlfavoxPoC.Controllers
{
    public class CompaniesController : Controller
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILocationRepository _locationRepository;
        private readonly ICompanyEmployeeRepository _companyEmployeeRepository;
        private readonly ICompanyLocationRepository _companyLocationRepository;
        private readonly ICompanyProductRepository _companyProductRepository;

        public CompaniesController(
            ICompanyRepository companyRepository,
            IEmployeeRepository employeeRepository,
            ILocationRepository locationRepository,
            ICompanyEmployeeRepository companyEmployeeRepository,
            ICompanyLocationRepository companyLocationRepository,
            ICompanyProductRepository companyProductRepository)
        {
            _companyRepository = companyRepository;
            _employeeRepository = employeeRepository;
            _locationRepository = locationRepository;
            _companyEmployeeRepository = companyEmployeeRepository;
            _companyLocationRepository = companyLocationRepository;
            _companyProductRepository = companyProductRepository;
        }

        // GET: Companies
        public IActionResult Index()
        {
            return View(_companyRepository.GetAll());
        }

        // GET: Companies/Details/5
        public IActionResult Details(int? id)
        {
            var companyId = (int)id;
            var company = _companyRepository.Get(companyId);
            if (company != null)
            {
                var employees = _companyEmployeeRepository.GetQueryable()
                    .Include(item => item.Employee)
                    .Where(cm => cm.CompanyId == id)
                    .ToList();

                var locations = _companyLocationRepository.GetQueryable()
                    .Include(item => item.Location)
                    .Where(cm => cm.CompanyId == id)
                    .ToList();

                var viewCompanyViewModel = new ViewCompanyViewModel
                {
                    Company = company,
                    CompanyEmployees = employees,
                    CompanyLocations = locations
                };

                return View(viewCompanyViewModel);
            }

            return NotFound();
        }

        // GET: Companies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Companies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("CompanyId,Name")] Company company)
        {
            if (ModelState.IsValid)
            {
                _companyRepository.Add(company);
                return RedirectToAction(nameof(Index));
            }
            return View(company);
        }

        // GET: Companies/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            int companyId = (int)id;
            var company = _companyRepository.Get(companyId);
            if (company == null)
            {
                return NotFound();
            }
            return View(company);
        }

        // POST: Companies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("CompanyId,Name")] Company company)
        {
            if (id != company.CompanyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _companyRepository.Update(company);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyExists(company.CompanyId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(company);
        }

        // GET: Companies/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            int companyId = (int)id;
            var company = _companyRepository.Get(companyId);

            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var company = _companyRepository.Get(id);
            if (company != null)
            {
                _companyRepository.Delete(company);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult AddEmployee(int id)
        {
            var company = _companyRepository.Get(id);
            if (company != null)
            {
                var employees = _employeeRepository.GetAll().ToList();
                if (employees != null && employees.Count > 0)
                {
                    var addEmployeeToCompanyViewModel = new AddEmployeeToCompanyViewModel(company, employees);
                    return View(addEmployeeToCompanyViewModel);
                }
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeToCompanyViewModel addEmployeeToCompanyViewModel)
        {
            if (ModelState.IsValid)
            {
                var employeeId = addEmployeeToCompanyViewModel.EmployeeId;
                var companyId = addEmployeeToCompanyViewModel.CompanyId;

                var existingItems = _companyEmployeeRepository.GetQueryable()
                    .Where(cm => cm.EmployeeId == employeeId)
                    .Where(cm => cm.CompanyId == companyId)
                    .ToList();

                if (existingItems.Count == 0)
                {
                    var newCompanyEmployee = new CompanyEmployee
                    {
                        EmployeeId = employeeId,
                        CompanyId = companyId
                    };
                    _companyEmployeeRepository.Add(newCompanyEmployee);
                    return Redirect("/Companies/Details?id=" + companyId);
                }
                else
                {
                    return Redirect("/Characters/Details?id=" + companyId);
                }
            }
            else
            {
                return View(addEmployeeToCompanyViewModel);
            }
        }

        [HttpGet]
        public IActionResult AddLocation(int id)
        {
            var company = _companyRepository.Get(id);
            if (company != null)
            {
                var locations = _locationRepository.GetAll().ToList();
                if (locations != null && locations.Count > 0)
                {
                    var addLocationToCompanyViewModel = new AddLocationToCompanyViewModel(company, locations);
                    return View(addLocationToCompanyViewModel);
                }
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult AddLocation(AddLocationToCompanyViewModel addLocationToCompanyViewModel)
        {
            if (ModelState.IsValid)
            {
                var locationId = addLocationToCompanyViewModel.LocationId;
                var companyId = addLocationToCompanyViewModel.CompanyId;

                var existingItems = _companyLocationRepository.GetQueryable()
                    .Where(cm => cm.LocationId == locationId)
                    .Where(cm => cm.CompanyId == companyId)
                    .ToList();

                if (existingItems.Count == 0)
                {
                    var companyLocation = new CompanyLocation
                    {
                        LocationId = locationId,
                        CompanyId = companyId
                    };
                    _companyLocationRepository.Add(companyLocation);
                    return Redirect("/Companies/Details?id=" + companyId);
                }
                else
                {
                    return Redirect("/Characters/Details?id=" + companyId);
                }
            }
            else
            {
                return View(addLocationToCompanyViewModel);
            }
        }

        private bool CompanyExists(int id)
        {
            return _companyRepository.GetAll().Any(e => e.CompanyId == id);
        }
    }
}
