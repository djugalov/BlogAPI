using Blog.Data;
using Blog.Models.Responses.Comment;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.BL.Commands.Comment
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, CreateCommentResponse>
    {
        private readonly BlogDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CreateCommentCommandHandler(BlogDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<CreateCommentResponse> Handle(CreateCommentCommand createCommentCommand, CancellationToken cancellationToken)
        {
            var authorId = _httpContextAccessor.HttpContext.Items["UserId"].ToString();

            var currentUser = await _context.ApplicationUsers
                .Include(x => x.AuthorUser)
                .FirstOrDefaultAsync(x => x.Id == new Guid(authorId), CancellationToken.None);

            var post = await _context.Posts
                .FirstOrDefaultAsync(x => x.Id == createCommentCommand.Request.Comment.PostId, CancellationToken.None);

            var response = new CreateCommentResponse { IsSuccess = false };

            if (post == null)
            {
                response.ResponseMessage = $"Post with the given id {createCommentCommand.Request.Comment.PostId} does not exist";
                return response;
            }

            if (currentUser == null)
            {
                response.ResponseMessage = "Users must be logged to add comments";
                return response;
            }

            var comment = new Data.DbModels.Comment
            {
                Author = currentUser.AuthorUser,
                Content = createCommentCommand.Request.Comment.Content,
                Post = post
            };

            await _context.Comments.AddAsync(comment, CancellationToken.None);

            await _context.SaveChangesAsync();

            response.IsSuccess = true;
            response.ResponseMessage = "Comment was added successfully";
            response.Comment = new Models.DTOs.Comment.CommentDetailsDto
            {
                Id =comment.Id,
                PostId = comment.Post.Id,
                Content = comment.Content,
                Downvotes = 0,
                Upvotes = 0
            };

            return response;
        }
    }
}
