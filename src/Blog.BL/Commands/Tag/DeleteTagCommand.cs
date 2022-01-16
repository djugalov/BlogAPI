using Blog.Models.DTOs.Tag;
using Blog.Models.Requests.Tag;
using MediatR;

namespace Blog.BL.Commands.Tag
{
    public class DeleteTagCommand : IRequest<DeleteTagResponse>
    {
        public DeleteTagCommand(DeleteTagRequest request)
        {
            Request = request;
        }
        public DeleteTagRequest Request { get; set; }
    }
}
