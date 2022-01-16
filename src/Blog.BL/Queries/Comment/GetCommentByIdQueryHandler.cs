using Blog.Data;
using Blog.Models.Responses.Comment;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.BL.Queries.Comment
{
    public class GetCommentByIdQueryHandler : IRequestHandler<GetCommentByIdQuery, GetCommentByIdResponse>
    {
        private readonly BlogDbContext _context;
        public GetCommentByIdQueryHandler(BlogDbContext context)
        {
            _context = context;
        }

        public async Task<GetCommentByIdResponse> Handle(GetCommentByIdQuery getCommentByIdQuery, CancellationToken cancellationToken)
        {
            var comment = await _context.Comments
                .Include(x => x.Post)
                .FirstOrDefaultAsync(x => x.Id == getCommentByIdQuery.Request.Id, CancellationToken.None);

            if (comment == null)
            {
                return new GetCommentByIdResponse
                {
                    IsSuccess = false,
                    ResponseMessage = $"Comment with the given id {getCommentByIdQuery.Request.Id} does not exist"
                };
            }

            return new GetCommentByIdResponse
            {
                IsSuccess = true,
                ResponseMessage = "Getting of comment was successfult",
                Comment = new Models.DTOs.Comment.CommentDetailsDto
                {
                    Id = comment.Id,
                    Content = comment.Content,
                    Upvotes = comment.Upvotes,
                    Downvotes = comment.Downvotes,
                    PostId = comment.Post.Id
                }
            };
        }
    }
}
