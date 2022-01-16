using Blog.Models.Requests.Comment;
using Blog.Models.Responses.Comment;
using MediatR;

namespace Blog.BL.Commands.Comment
{
    public class DeleteCommentCommand : IRequest<DeleteCommentResponse>
    {
        public DeleteCommentCommand(DeleteCommentRequest request)
        {
            Request = request;
        }

        public DeleteCommentRequest Request { get; set; }
    }
}
