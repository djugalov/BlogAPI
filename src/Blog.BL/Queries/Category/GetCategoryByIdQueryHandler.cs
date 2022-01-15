using Blog.Data;
using Blog.Models.Responses.Category;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.BL.Queries.Category
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, GetCategoryByIdResponse>
    {
        private readonly BlogDbContext _context;

        public GetCategoryByIdQueryHandler(BlogDbContext context)
        {
            _context = context;
        }

        public async Task<GetCategoryByIdResponse> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == request.Id);

            if(category != null)
            {
                return new GetCategoryByIdResponse
                {
                    Category = new Models.DTOs.Category.BaseCategoryDto
                    {
                        Id = category.Id,
                        Name = category.Name
                    },
                    IsSuccess = true,
                    ResponseMessage = "Getting of category was successful"
                };
            }

            return new GetCategoryByIdResponse
            {
                IsSuccess = false,
                ResponseMessage = $"Could not get category with the following id {request.Id}"
            };
        }
    }
}
