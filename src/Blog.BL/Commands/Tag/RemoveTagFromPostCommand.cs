using Blog.Models.Requests.Tag;
using Blog.Models.Responses.Tag;
using MediatR;

namespace Blog.BL.Commands.Tag
{
    public class RemoveTagFromPostCommand : IRequest<RemoveTagFromPostResponse>
    {
        public RemoveTagFromPostCommand(RemoveTagFromPostRequest request)
        {
            Request = request;
        }
        public RemoveTagFromPostRequest Request { get; set; }
    }
}
