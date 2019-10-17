using LinnworksTest.Controllers;
using System;
using Xunit;
using Moq;
using LinnworksTest.DataAccess;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Tests
{
    public class BackEndTests
    {
        private readonly Mock<IGenericRepository<Category>> rep;
        private readonly CategoryController sut;

        public BackEndTests()
        {
            rep = new Mock<IGenericRepository<Category>>();
            sut = new CategoryController(rep.Object);
        }

        [Fact]
        public void CheckCategoryCreaion()
        {
            var categryModel = new LinnworksTest.Models.Category()
            { CategoryName = "test" };
            var guid = Guid.NewGuid();
            rep.Setup(x => x.CreateAsync(It.IsAny<Category>())).Returns
                (Task.FromResult(new Category { CategoryName = "test", Id = guid }));
            var catecry = sut.Create(categryModel).Result;
            Assert.Equal(guid, catecry.CategoryId);
        }

        [Fact]
        public async Task DetailsTestEmpty()
        {
            var result = await sut.Details(string.Empty);
            Assert.IsType<BadRequestResult>(result);
        }
        [Fact]
        public async Task DetailsTestNotGUID()
        {
            var result = await sut.Details("notGUID");
            Assert.IsType<BadRequestResult>(result);
        }
        [Fact]
        public async Task DetailsTestOK()
        {
            rep.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).Returns(Task.FromResult(new Category()));
            var det = await sut.Details(Guid.NewGuid().ToString());
            Assert.IsType<OkObjectResult>(det);

        }
        [Fact]
        public async Task DetailsTestNotFond()
        {
            Category catgory = null;
            rep.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).Returns(Task.FromResult(catgory));
            var det = await sut.Details(Guid.NewGuid().ToString());
            Assert.IsType<NotFoundResult>(det);

        }
    }
}
