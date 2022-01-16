using Blog.Data;
using Blog.Models.Responses.Tag;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.BL.Commands.Tag
{
    public class RemoveTagFromPostCommandHandler : IRequestHandler<RemoveTagFromPostCommand, RemoveTagFromPostResponse>
    {
        private readonly BlogDbContext _context;

        public RemoveTagFromPostCommandHandler(BlogDbContext context)
        {
            _context = context;
        }

        public async Task<RemoveTagFromPostResponse> Handle(RemoveTagFromPostCommand command, CancellationToken cancellationToken)
        {
            var postTagMap = await _context.PostTagMaps
                .FirstOrDefaultAsync(x => x.Post.Id == command.Request.TagToBeRemovedFromPost.PostId
                && x.Tag.Id == command.Request.TagToBeRemovedFromPost.TagId, CancellationToken.None);

            if (postTagMap == null)
            {
                return new RemoveTagFromPostResponse
                {
                    IsSuccess = false,
                    ResponseMessage = $"Tag with id {command.Request.TagToBeRemovedFromPost.TagId} has no relation to post with id {command.Request.TagToBeRemovedFromPost.PostId}"
                };
            }

            _context.PostTagMaps.Remove(postTagMap);

            await _context.SaveChangesAsync(CancellationToken.None);

            return new RemoveTagFromPostResponse
            {
                IsSuccess = true,
                ResponseMessage = "Tag was removed from post"
            };
        }
    }
}
