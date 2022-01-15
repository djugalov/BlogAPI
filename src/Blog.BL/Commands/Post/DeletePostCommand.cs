using Blog.Models.Requests.Post;
using Blog.Models.Responses.Post;
using MediatR;

namespace Blog.BL.Commands.Post
{
    public class DeletePostCommand : IRequest<DeletePostResponse>
    {
        public DeletePostCommand(DeletePostRequest request)
        {
            Request = request;
        }

        public DeletePostRequest Request { get; set; }
    }
}
