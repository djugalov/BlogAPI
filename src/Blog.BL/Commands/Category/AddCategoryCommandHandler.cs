using Blog.Data;
using Blog.Models.Responses.Category;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.BL.Commands.Category
{
    public class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommand, AddCategoryResponse>
    {
        private readonly BlogDbContext _context;
        public AddCategoryCommandHandler(BlogDbContext context)
        {
            _context = context;
        }

        public async Task<AddCategoryResponse> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _context.Categories.AddAsync(new Data.DbModels.Category
            {
                Name = request.Category.Name
            });

            await _context.SaveChangesAsync();

            return new AddCategoryResponse
            {
                Id = category.Entity.Id,
                Name = category.Entity.Name
            };
        }
    }
}
