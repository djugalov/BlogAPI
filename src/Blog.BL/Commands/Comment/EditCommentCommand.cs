using Blog.Models.Requests.Comment;
using Blog.Models.Requests.Post;
using MediatR;

namespace Blog.BL.Commands.Comment
{
    public class EditCommentCommand : IRequest<EditCommentResponse>
    {
        public EditCommentCommand(EditCommentRequest request)
        {
            Request = request;
        }

        public EditCommentRequest Request { get; set; }
    }
}
