using AlfavoxPoC.Core.Domain;
using AlfavoxPoC.Persistence;
using AlfavoxPoC.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Xunit;

namespace AlfavoxPoC.Tests.AlfavoxPoC.Persistence.Repositories.Tests
{
    /// <summary>
    /// Integration tests for the CompanyRepository class
    /// Naming convention: MethodName_ExpectedBehavior_StateUnderTest
    /// </summary>
    public sealed class CompanyRepositoryTests
    {
        [Fact]
        public void GetAll_ShouldReturnCompanies_WhenParticularNumberOfCompaniessWereAdded()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<AlfavoxDbContext>()
                .UseInMemoryDatabase(databaseName: "AlfavoxDB")
                .Options;

            var context = new AlfavoxDbContext(options);
            var repository = new CompanyRepository(context);

            // Act
            InitializeCompanies(context);
            var result = repository.GetAll().ToList();

            // Assert
            Assert.Equal(3, result.Count);
        }

        [Fact]
        public void Get_ShouldReturnSpecificCompany_AfterGivenIdOfPickedCompany()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<AlfavoxDbContext>()
                .UseInMemoryDatabase(databaseName: "AlfavoxDB")
                .Options;

            var context = new AlfavoxDbContext(options);
            var repository = new CompanyRepository(context);

            // Act
            InitializeCompanies(context);
            var result = repository.Get(1);

            // Assert
            Assert.Equal("Alfavox", result.Name);
        }

        [Fact]
        public void Add_ShouldReturnSingleCompany_WhenJustOneWasAdded()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<AlfavoxDbContext>()
                .UseInMemoryDatabase(databaseName: "AlfavoxDB")
                .Options;

            var context = new AlfavoxDbContext(options);
            var repository = new CompanyRepository(context);

            // Act
            repository.Add(new Company() { Name = "AlfavoxCompany" });
            var result = repository.GetAll().ToList();

            // Assert
            Assert.Single(result);
        }

        [Fact]
        public void Delete_ShouldReturnDecrementedCounter_WhenOneOfTheCompaniesWasRemoved()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<AlfavoxDbContext>()
                .UseInMemoryDatabase(databaseName: "AlfavoxDB")
                .Options;

            var context = new AlfavoxDbContext(options);
            var repository = new CompanyRepository(context);

            // Act
            InitializeCompanies(context);
            var result = repository.GetAll().ToList();
            repository.Delete(result.First());
            var resultAfterDeletePerformed = repository.GetAll().ToList();

            // Assert
            Assert.Equal(resultAfterDeletePerformed.Count, result.Count - 1);
        }

        [Fact]
        public void Update_ShouldReturnDifferentCompanyName_WhenCompanyNameHasBeenModified()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<AlfavoxDbContext>()
                .UseInMemoryDatabase(databaseName: "AlfavoxDB")
                .Options;

            var context = new AlfavoxDbContext(options);
            var repository = new CompanyRepository(context);

            // Act
            InitializeCompanies(context);
            var result = repository.GetAll().ToList();
            var originalCompany = result.First();
            var originalCompanyName = originalCompany.Name;

            originalCompany.Name = "Nova";
            repository.Update(originalCompany);

            var updateCompanyName = repository.Get(1).Name;

            // Assert
            Assert.NotEqual(originalCompanyName, updateCompanyName);
        } 

        private void InitializeCompanies(AlfavoxDbContext context)
        {
            var planets = new Company[]
            {
                new Company() { Name = "Alfavox" },
                new Company() { Name = "Intel" },
                new Company() { Name = "CodePepper" },
            };

            context.Compenies.AddRange(planets);
            context.SaveChanges();
        }
    }
}
