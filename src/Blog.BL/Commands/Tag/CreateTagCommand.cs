using Blog.Models.Requests.Tag;
using Blog.Models.Responses.Tag;
using MediatR;

namespace Blog.BL.Commands.Tag
{
    public class CreateTagCommand : IRequest<CreateTagResponse>
    {
        public CreateTagCommand(CreateTagRequest request)
        {
            Request = request;
        }

        public CreateTagRequest Request { get; set; }
    }
}
