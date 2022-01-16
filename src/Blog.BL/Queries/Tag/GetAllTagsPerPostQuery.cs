using Blog.Models.Requests.Tag;
using Blog.Models.Responses.Tag;
using MediatR;

namespace Blog.BL.Queries.Tag
{
    public class GetAllTagsPerPostQuery : IRequest<GetAllTagsPerPostResponse>
    {
        public GetAllTagsPerPostQuery(GetAllTagsPerPostRequest request)
        {
            Request = request;
        }
        public GetAllTagsPerPostRequest Request { get; set; }
    }
}
