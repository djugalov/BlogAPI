using Blog.Models.Requests.Comment;
using Blog.Models.Responses.Comment;
using MediatR;

namespace Blog.BL.Commands.Comment
{
    public class CreateCommentCommand : IRequest<CreateCommentResponse>
    {
        public CreateCommentCommand(CreateCommentRequest request)
        {
            Request = request;
        }

        public CreateCommentRequest Request { get; set; }
    }
}
