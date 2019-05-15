using AlfavoxPoC.Controllers;
using AlfavoxPoC.Core.Domain;
using AlfavoxPoC.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace AlfavoxPoC.Tests.AlfavoxPoC.Controllers.Tests
{
    /// <summary>
    /// Unit tests for the CompaniesController class
    /// Naming convention: MethodName_ExpectedBehavior_StateUnderTest
    /// </summary>
    public sealed class CompaniesControllerTests
    {
        [Fact]
        public void Index_ReturnsAViewResult_WithAListOfCompanies()
        {
            // Arrange
            var mockEmployeeRepository = new Mock<IEmployeeRepository>();
            var mockProductRepository = new Mock<IProductRepository>();
            var mockLocationRepository = new Mock<ILocationRepository>();
            var mockCompanyEmployeeRepository = new Mock<ICompanyEmployeeRepository>();
            var mockCompanyLocationRepository = new Mock<ICompanyLocationRepository>();
            var mockCompanyProductRepository = new Mock<ICompanyProductRepository>();
            var mockCompanyRepository = new Mock<ICompanyRepository>();
            mockCompanyRepository.Setup(repo => repo.GetAll())
                .Returns(GetCompanies());

            var controller = new CompaniesController(
                mockCompanyRepository.Object,
                mockEmployeeRepository.Object,
                mockLocationRepository.Object,
                mockCompanyEmployeeRepository.Object,
                mockCompanyLocationRepository.Object,
                mockCompanyProductRepository.Object);

            // Act
            var result = controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Company>>(
                viewResult.ViewData.Model);
            Assert.Equal(3, model.Count());
        }

        [Fact]
        public void Edit_ReturnsNotFoundActionResult_NotExisitingId()
        {
            // Arrange
            var mockEmployeeRepository = new Mock<IEmployeeRepository>();
            var mockProductRepository = new Mock<IProductRepository>();
            var mockLocationRepository = new Mock<ILocationRepository>();
            var mockCompanyEmployeeRepository = new Mock<ICompanyEmployeeRepository>();
            var mockCompanyLocationRepository = new Mock<ICompanyLocationRepository>();
            var mockCompanyProductRepository = new Mock<ICompanyProductRepository>();
            var mockCompanyRepository = new Mock<ICompanyRepository>();
            mockCompanyRepository.Setup(repo => repo.GetAll())
                .Returns(GetCompanies());

            var controller = new CompaniesController(
                mockCompanyRepository.Object,
                mockEmployeeRepository.Object,
                mockLocationRepository.Object,
                mockCompanyEmployeeRepository.Object,
                mockCompanyLocationRepository.Object,
                mockCompanyProductRepository.Object);

            // Act
            var result = (NotFoundResult)controller.Edit(666);

            // Assert
            Assert.Equal(404, result.StatusCode);
        }

        private List<Company> GetCompanies()
        {
            var companies = new List<Company>();
            companies.Add(new Company()
            {
                CompanyId = 1,
                Name = "Alfavox"
            });
            companies.Add(new Company()
            {
                CompanyId = 2,
                Name = "Intel"
            });
            companies.Add(new Company()
            {
                CompanyId = 3,
                Name = "Code&Pepper"
            });
            return companies;
        }
    }
}
