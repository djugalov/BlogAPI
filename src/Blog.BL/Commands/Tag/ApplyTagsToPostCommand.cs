using Blog.Models.Requests.Tag;
using Blog.Models.Responses.Tag;
using MediatR;

namespace Blog.BL.Commands.Tag
{
    public class ApplyTagsToPostCommand : IRequest<ApplyTagsToPostResponse>
    {
        public ApplyTagsToPostCommand(ApplyTagsToPostRequest request)
        {
            Request = request;
        }

        public ApplyTagsToPostRequest Request { get; set; }
    }
}
