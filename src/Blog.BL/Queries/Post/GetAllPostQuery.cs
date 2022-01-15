using Blog.Models.Responses.Post;
using MediatR;

namespace Blog.BL.Queries.Post
{
    public class GetAllPostQuery : IRequest<GetAllPostsResponse>
    {
    }
}
