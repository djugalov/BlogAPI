using Blog.Data;
using Blog.Models.DTOs.Comment;
using Blog.Models.Responses.Comment;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.BL.Queries.Comment
{
    public class GetCommentsForPostQueryHandler : IRequestHandler<GetCommentsForPostQuery, GetCommentsForPostResponse>
    {
        private readonly BlogDbContext _context;
        public GetCommentsForPostQueryHandler(BlogDbContext context)
        {
            _context = context;
        }
        public async Task<GetCommentsForPostResponse> Handle(GetCommentsForPostQuery getCommentsForPostQuery, CancellationToken cancellationToken)
        {
            var post = await _context.Posts.FirstOrDefaultAsync(x => x.Id == getCommentsForPostQuery.Request.PostId);

            if (post == null)
            {
                return new GetCommentsForPostResponse
                {
                    IsSuccess = false,
                    ResponseMessage = $"Post with the given id {getCommentsForPostQuery.Request.PostId} does not exist"
                };
            }

            var comments = await _context.Comments
                .Where(x => x.Post.Id == getCommentsForPostQuery.Request.PostId)
                .Select(x => new CommentDetailsDto
                {
                    Id = x.Id,
                    Content = x.Content,
                    Upvotes = x.Upvotes,
                    Downvotes = x.Downvotes,
                    PostId = x.Post.Id
                })
                .ToListAsync();

            return new GetCommentsForPostResponse
            {
                IsSuccess = true,
                ResponseMessage = "Getting of comments was successfuly",
                Comments = comments
            };
        }
    }
}
