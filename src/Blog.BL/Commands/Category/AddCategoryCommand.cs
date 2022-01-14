using Blog.Models.Requests.Category;
using Blog.Models.Responses.Category;
using MediatR;

namespace Blog.BL.Commands.Category
{
    public class AddCategoryCommand : IRequest<AddCategoryResponse>
    {
        public AddCategoryCommand(AddCategoryRequest request)
        {
            Category = request;
        }
        public AddCategoryRequest Category { get; private set; }
    }
}
