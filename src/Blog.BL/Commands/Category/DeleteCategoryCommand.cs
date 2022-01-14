using Blog.Models.Requests.Category;
using Blog.Models.Responses.Category;
using MediatR;

namespace Blog.BL.Commands.Category
{
    public class DeleteCategoryCommand : IRequest<DeleteCategoryResponse>
    {
        public DeleteCategoryCommand(DeleteCategoryRequest request)
        {
            Request = request;
        }

        public DeleteCategoryRequest Request { get; set; }
    }
}
