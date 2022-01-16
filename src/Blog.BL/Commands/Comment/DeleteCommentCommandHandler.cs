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

namespace Blog.BL.Commands.Comment
{
    public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand, DeleteCommentResponse>
    {
        private readonly BlogDbContext _context;
        public DeleteCommentCommandHandler(BlogDbContext context)
        {
            _context = context;
        }

        public async Task<DeleteCommentResponse> Handle(DeleteCommentCommand deleteCommentCommand, CancellationToken cancellationToken)
        {
            var comment = await _context.Comments.FirstOrDefaultAsync(x => x.Id == deleteCommentCommand.Request.Id);

            if(comment == null)
            {
                return new DeleteCommentResponse
                {
                    IsSuccess = false,
                    ResponseMessage = $"Comment with the given id {deleteCommentCommand.Request.Id} does not exist"
                };
            }

            _context.Comments.Remove(comment);

            await _context.SaveChangesAsync();

            return new DeleteCommentResponse
            {
                IsSuccess = true,
                ResponseMessage = "Comment was deleted successfully"
            };
        }
    }
}
