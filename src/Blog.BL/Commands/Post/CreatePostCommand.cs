using Blog.Models.Requests.Post;
using Blog.Models.Responses.Post;
using MediatR;

namespace Blog.BL.Commands.Post
{
    public class CreatePostCommand : IRequest<CreatePostResponse>
    {
        public CreatePostCommand(CreatePostRequest request)
        {
            Request = request;
        }

        public CreatePostRequest Request { get; set; }
    }
}
