using LinnworksTest.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.SqlServer;
using Xunit;
using System.Threading.Tasks;
using System.Linq;

namespace Tests
{
    public class DataBaseTests
    {
        private readonly CategoriesManagementContext ctx;
        private readonly GenericRepository<Category> rep;

        public DataBaseTests()
        {
            var bld = new DbContextOptionsBuilder<CategoriesManagementContext>()
                .UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Linnworks.TestDb;Trusted_Connection=True;");
            ctx = new CategoriesManagementContext
               (bld.Options);
            rep = new GenericRepository<Category>(ctx);
        }

        [Fact]
        public async Task Create()
        {
            var ret = await rep.CreateAsync(new Category());
            Assert.NotEqual(Guid.Empty, ret.Id);
        }
        [Fact]
        public async Task GetById()
        {
            var ret = await rep.CreateAsync(new Category());
            var toCheck = ret.Id;
            var get = await rep.GetByIdAsync(toCheck);
            Assert.Equal(toCheck, get.Id);
        }
        [Fact]
        public async Task GetAll()
        {
            var myCategory = new Category() { CategoryName = "ToAll" };
            var ret = await rep.CreateAsync(myCategory);
            var allCategoris = await rep.GetAllAsync();
            Assert.NotNull(allCategoris.Where(x=>x.Id == ret.Id));
        }
        [Fact]
        public async Task Delete()
        {
            var repo = RecreateContext("Server=localhost\\SQLEXPRESS;Database=Linnworks.TestDb;Trusted_Connection=True;");
            var ret = await rep.CreateAsync(new Category());
            await repo.DeleteAsync(ret.Id);
            var allCategoris = await rep.GetAllAsync();
            Assert.Null(allCategoris.Where(x => x.Id == ret.Id));
        }

        private GenericRepository<Category> RecreateContext(string conntionSting)
        {
            var builder = new DbContextOptionsBuilder<CategoriesManagementContext>()
                .UseSqlServer(conntionSting);
            var dbContext = new CategoriesManagementContext
               (builder.Options);
            var repo = new GenericRepository<Category>(ctx);
            return repo;
        }
    }
    
}

