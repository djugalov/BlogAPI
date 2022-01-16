using Blog.Models.Requests.Comment;
using Blog.Models.Responses.Comment;
using MediatR;

namespace Blog.BL.Queries.Comment
{
    public class GetCommentByIdQuery : IRequest<GetCommentByIdResponse>
    {
        public GetCommentByIdQuery(GetCommentByIdRequest request)
        {
            Request = request;
        }
        public GetCommentByIdRequest Request { get; set; }
    }
}
