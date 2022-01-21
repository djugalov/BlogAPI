using Blog.BL.Commands.Category;
using Blog.Data;
using Blog.Models.Requests.Category;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;
using CategoryDbModel = Blog.Data.DbModels.Category;
using Microsoft.EntityFrameworkCore;
using Blog.Models.Responses.Category;
using Microsoft.Data.Sqlite;

namespace BlogApi.BL.Unit.Tests.Category
{
    [TestFixture]
    public class AddCategoryCommandHandlerTests
    {
        private const string InMemoryConnectionString = "Datasource=:memory:";

        private SqliteConnection _connection;

        private BlogDbContext _context;

        [SetUp]
        public void Setup()
        {
            CreateContext();
        }

        [TearDown]
        public void TearDown()
        {
            _connection.Close();

            _context.Database.EnsureDeleted();
        }

        [Test]
        public async Task AddCategoryReturnsResponseOfTypeAddCategoryResponse()
        {
            //Arrange
            var request = new AddCategoryRequest
            {
                Name = "TestDriveV12"
            };

            var command = new AddCategoryCommand(request);

            var addCategoryCommandHandler = new AddCategoryCommandHandler(_context);

            //Act
            var response = await addCategoryCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.IsAssignableFrom<AddCategoryResponse>(response, "Response is not of type AddCategoryResponse");
        }

        [Test]
        public async Task AddCategoryWithUniqueNameReturnsIsSuccessTrue()
        {
            //Arrange
            var request = new AddCategoryRequest
            {
                Name = "oopp"
            };
            var command = new AddCategoryCommand(request);
            var addCategoryCommandHandler = new AddCategoryCommandHandler(_context);

            //Act
            var response = await addCategoryCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.IsTrue(response.IsSuccess);
        }

        [Test]
        public async Task AddCategoryCommandHandlerReturnsIsSuccessFalseWhenCategoryWithTheSameNameExist()
        {
            //Arrange

            var request = new AddCategoryRequest
            {
                Name = "Test"
            };

            var command = new AddCategoryCommand(request);

            var addCategoryCommandHandler = new AddCategoryCommandHandler(_context);

            //Act
            var response = await addCategoryCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.IsFalse(response.IsSuccess);
        }

        private void CreateContext()
        {
            _connection = new SqliteConnection(InMemoryConnectionString);

            _connection.Open();

            var options = new DbContextOptionsBuilder<BlogDbContext>()
                    .UseSqlite(_connection)
                    .Options;

            _context = new BlogDbContext(options);

            _context.Database.EnsureCreated();

            SeedDbWithCategory();
        }

        private void SeedDbWithCategory()
        {
            _context.Categories.Add(new CategoryDbModel { Name = "Test" });

            _context.SaveChanges();
        }
    }
}
