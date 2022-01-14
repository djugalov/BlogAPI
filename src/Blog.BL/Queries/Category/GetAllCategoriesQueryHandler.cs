using Blog.Data;
using Blog.Models.DTOs.Category;
using Blog.Models.Responses.Category;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.BL.Queries.Category
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, GetAllCategoriesResponse>
    {
        private readonly BlogDbContext _context;

        public GetAllCategoriesQueryHandler(BlogDbContext context)
        {
            _context = context;
        }

        public Task<GetAllCategoriesResponse> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var getAllCategoriesResponse = new GetAllCategoriesResponse();

            getAllCategoriesResponse.Categories = _context.Categories.Select(x => new BaseCategoryDto
            { 
                Id = x.Id,
                Name = x.Name 
            });

            return Task.FromResult(getAllCategoriesResponse);
        }
    }
}
