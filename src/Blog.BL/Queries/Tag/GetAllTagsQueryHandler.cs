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
    public class GetAllTagsQueryHandler : IRequestHandler<GetAllTagsQuery, GetAllTagsResponse>
    {
        private readonly BlogDbContext _context;

        public GetAllTagsQueryHandler(BlogDbContext context)
        {
            _context = context;
        }

        public async Task<GetAllTagsResponse> Handle(GetAllTagsQuery request, CancellationToken cancellationToken)
        {
            var tags = await _context.Tags
                .Select(x => new TagDetailsDto
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ToListAsync();

            return new GetAllTagsResponse
            {
                Tags = tags
            };
        }
    }
}
