using Blog.Models.Requests.Comment;
using Blog.Models.Responses.Comment;
using MediatR;

namespace Blog.BL.Queries.Comment
{
    public class GetCommentsForPostQuery : IRequest<GetCommentsForPostResponse>
    {
        public GetCommentsForPostQuery(GetCommentsForPostRequest request)
        {
            Request = request;
        }

        public GetCommentsForPostRequest Request { get; set; }
    }
}
