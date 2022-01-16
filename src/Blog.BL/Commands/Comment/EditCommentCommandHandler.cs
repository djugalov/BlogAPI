using Blog.Data;
using Blog.Models.Requests.Post;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.BL.Commands.Comment
{
    public class EditCommentCommandHandler : IRequestHandler<EditCommentCommand, EditCommentResponse>
    {
        private readonly BlogDbContext _context;
        private readonly IHttpContextAccessor _httpContext;
        public EditCommentCommandHandler(BlogDbContext context, IHttpContextAccessor httpContext)
        {
            _context = context;
            _httpContext = httpContext;
        }

        public async Task<EditCommentResponse> Handle(EditCommentCommand editCommentCommand, CancellationToken cancellationToken)
        {
            var comment = await _context.Comments
                .Include(x => x.Author)
                .Include(x => x.Post)
                .FirstOrDefaultAsync(x => x.Id == editCommentCommand.Request.Comment.Id, CancellationToken.None);

            var response = await Validate(comment, editCommentCommand);

            if(response != null)
            {
                return response;
            }

            comment.Content = editCommentCommand.Request.Comment.Content;

            await _context.SaveChangesAsync(CancellationToken.None);

            return new EditCommentResponse
            {
                IsSuccess = true,
                ResponseMessage = "Comment was edited successfully",
                Comment = new Models.DTOs.Comment.CommentDetailsDto
                {
                    Id = comment.Id,
                    Content = comment.Content,
                    PostId = comment.Post.Id,
                    Downvotes = comment.Downvotes,
                    Upvotes = comment.Upvotes
                }
            };
        }

        private async Task<EditCommentResponse> Validate(Data.DbModels.Comment comment, EditCommentCommand editCommentCommand)
        {
            if (comment == null)
            {
                return new EditCommentResponse
                {
                    IsSuccess = false,
                    ResponseMessage = $"Comment with the given id {editCommentCommand.Request.Comment.Id} does not exist"
                };
            }

            var loggedInUser = await _context.ApplicationUsers.Include(x => x.AuthorUser).FirstOrDefaultAsync(x => x.Id.ToString() == _httpContext.HttpContext.Items["UserId"].ToString());

            if (loggedInUser?.AuthorUser?.Id != comment.Author.Id)
            {
                return new EditCommentResponse
                {
                    IsSuccess = false,
                    ResponseMessage = $"Only the author of the comment can edit it"
                };
            }

            return null;
        }
    }
}
