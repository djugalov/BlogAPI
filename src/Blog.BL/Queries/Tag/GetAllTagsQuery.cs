using Blog.Models.Responses.Tag;
using MediatR;

namespace Blog.BL.Queries.Tag
{
    public class GetAllTagsQuery : IRequest<GetAllTagsResponse>
    {
    }
}
