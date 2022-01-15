using Blog.Data;
using Blog.Models.Responses.Category;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.BL.Commands.Category
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, DeleteCategoryResponse>
    {
        private readonly BlogDbContext _context;
        public DeleteCategoryCommandHandler(BlogDbContext context)
        {
            _context = context;
        }

        public async Task<DeleteCategoryResponse> Handle(DeleteCategoryCommand deleteCategoryCommand, CancellationToken cancellationToken)
        {
            var category = await _context.Categories.FindAsync(deleteCategoryCommand.Request.Id);

            if (category != null)
            {
                _context.Remove(category);

                await _context.SaveChangesAsync();

                return new DeleteCategoryResponse
                {
                    IsSuccess = true,
                    ResponseMessage = "Category was deleted successfully"
                };
            }

            return new DeleteCategoryResponse
            {
                IsSuccess = false,
                ResponseMessage = $"The provided id {deleteCategoryCommand.Request.Id} does not match any existing category"
            };
        }
    }
}
