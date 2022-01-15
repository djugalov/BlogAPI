using Blog.Data;
using Blog.Models.Responses.Post;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.BL.Commands.Post
{
    public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand, DeletePostResponse>
    {
        private readonly BlogDbContext _context;
        public DeletePostCommandHandler(BlogDbContext context)
        {
            _context = context;
        }
        public async Task<DeletePostResponse> Handle(DeletePostCommand deletePostCommand, CancellationToken cancellationToken)
        {
            var post = await _context.Posts.FindAsync(new object[] { deletePostCommand.Request.Id }, CancellationToken.None);

            if(post == null)
            {
                return new DeletePostResponse
                {
                    IsSuccess = false,
                    ResponseMessage = $"Post with the given id {deletePostCommand.Request.Id} does not exist"
                };
            }

            _context.Posts.Remove(post);

            await _context.SaveChangesAsync(CancellationToken.None);

            return new DeletePostResponse
            {
                IsSuccess = true,
                ResponseMessage = "Post was deleted successfully"
            };
        }
    }
}
