using AlfavoxPoC.Core.Domain;
using AlfavoxPoC.Core.ViewModels;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AlfavoxPoC.Tests.AlfavoxPoC.Core.ViewModels.Tests
{
    /// <summary>
    /// Unit tests for the AddEmployeeToCompanyViewModelTests class
    /// Naming convention: MethodName_ExpectedBehavior_StateUnderTest
    /// </summary>
    public sealed class AddEmployeeToCompanyViewModelTests
    {
        [Fact]
        public void Ctor_Should_SetupCompany()
        {
            // Arrange
            var company = new Company() { Name = "Alfavox" };
            var employees = new List<Employee>() { new Employee(), new Employee() };

            // Act
            var viewModel = new AddEmployeeToCompanyViewModel(company, employees);
            var result = viewModel.Company;

            // Assert
            Assert.Equal(company, result);
        }

        [Fact]
        public void Ctor_ShouldSetupListOfEmployees_InitializedEmployees()
        {
            // Arrange
            var company = new Company() { Name = "Alfavox" };
            var employees = new List<Employee>() { new Employee(), new Employee() };

            // Act
            var viewModel = new AddEmployeeToCompanyViewModel(company, employees);
            var result = viewModel.Employees;

            // Assert
            Assert.Equal(employees.Count(), result.Count());
        }
    }
}
