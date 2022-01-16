using Blog.Data;
using Blog.Data.DbModels;
using Blog.Models.Responses.Tag;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.BL.Commands.Tag
{
    public class ApplyTagsToPostCommandHandler : IRequestHandler<ApplyTagsToPostCommand, ApplyTagsToPostResponse>
    {
        private readonly BlogDbContext _context;
        public ApplyTagsToPostCommandHandler(BlogDbContext context)
        {
            _context = context;
        }

        public async Task<ApplyTagsToPostResponse> Handle(ApplyTagsToPostCommand command, CancellationToken cancellationToken)
        {
            var post = await _context.Posts
                .FirstOrDefaultAsync(x => x.Id == command.Request.TagsToApply.PostId, CancellationToken.None);

            if(post == null)
            {
                return new ApplyTagsToPostResponse
                {
                    IsSuccess = true,
                    ResponseMessage = $"Post with the given id {command.Request.TagsToApply.PostId} does not exist"
                };
            }

            var tags = await _context.Tags
                .Where(x => command.Request.TagsToApply.TagsIds.Contains(x.Id))
                .ToListAsync(CancellationToken.None);

            var postTagMaps = new HashSet<PostTagMap>();

            tags.ForEach(x => postTagMaps.Add(new PostTagMap
            {
                Post = post,
                Tag = x
            }));

            await _context.PostTagMaps.AddRangeAsync(postTagMaps);

            return new ApplyTagsToPostResponse
            {
                IsSuccess = true,
                ResponseMessage = "Tags were applied to post"
            };
        }
    }
}
