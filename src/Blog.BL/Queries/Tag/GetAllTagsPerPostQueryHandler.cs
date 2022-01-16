using Blog.Data;
using Blog.Models.DTOs.Tag;
using Blog.Models.Responses.Tag;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.BL.Queries.Tag
{
    public class GetAllTagsPerPostQueryHandler : IRequestHandler<GetAllTagsPerPostQuery, GetAllTagsPerPostResponse>
    {
        private readonly BlogDbContext _context;
        public GetAllTagsPerPostQueryHandler(BlogDbContext context)
        {
            _context = context;
        }
        public async Task<GetAllTagsPerPostResponse> Handle(GetAllTagsPerPostQuery query, CancellationToken cancellationToken)
        {
            var tags = await _context.PostTagMaps
                .Where(x => x.Post.Id == query.Request.PostId)
                .Select(x => new TagDetailsDto
                {
                    Id = x.Tag.Id,
                    Name = x.Tag.Name
                })
                .ToListAsync();

            return new GetAllTagsPerPostResponse
            {
                IsSuccess = true,
                ResponseMessage = "Getting of tags was successful",
                Tags = tags
            };
        }
    }
}
