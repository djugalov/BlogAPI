using Blog.Models.Requests.Category;
using Blog.Models.Responses.Category;
using MediatR;

namespace Blog.BL.Commands.Category
{
    public class EditCategoryCommand : IRequest<EditCategoryResponse>
    {
        public EditCategoryCommand(EditCategoryRequest category)
        {
            Category = category;
        }
        public EditCategoryRequest Category { get; set; }
    }
}
