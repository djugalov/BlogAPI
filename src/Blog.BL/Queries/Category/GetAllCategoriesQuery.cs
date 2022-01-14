using Blog.Models.Responses.Category;
using MediatR;

namespace Blog.BL.Queries.Category
{
    public class GetAllCategoriesQuery : IRequest<GetAllCategoriesResponse>
    {
    }
}
