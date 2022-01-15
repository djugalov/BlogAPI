using Blog.Models.Requests.Post;
using Blog.Models.Responses.Post;
using MediatR;

namespace Blog.BL.Queries.Post
{
    public class GetPostByIdQuery : IRequest<GetPostByIdResponse>
    {
        public GetPostByIdQuery(GetPostByIdRequest request)
        {
            Request = request;
        }

        public GetPostByIdRequest Request { get; set; }
    }
}
