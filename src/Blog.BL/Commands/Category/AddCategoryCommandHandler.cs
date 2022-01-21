using Blog.Data;
using Blog.Models.Responses.Category;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
            try
            {
                var category = await _context.Categories.AddAsync(new Data.DbModels.Category
                {
                    Name = request.Category.Name
                }, CancellationToken.None);

                await _context.SaveChangesAsync(CancellationToken.None);

                return new AddCategoryResponse
                {
                    IsSuccess = true,
                    ResponseMessage = "Category was added successfully",
                    Id = category.Entity.Id,
                    Name = category.Entity.Name
                };
            }
            catch (DbUpdateException)
            {
                return new AddCategoryResponse
                {
                    IsSuccess = false,
                    ResponseMessage = "Category with the same name already exist"
                };
            }
        }
    }
}
