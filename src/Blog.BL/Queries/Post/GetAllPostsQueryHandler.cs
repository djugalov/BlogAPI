using Blog.BL.Helpers;
using Blog.Data;
using Blog.Models.DTOs.Post;
using Blog.Models.Responses.Post;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.BL.Queries.Post
{
    public class GetAllPostsQueryHandler : IRequestHandler<GetAllPostQuery, GetAllPostsResponse>
    {
        private readonly BlogDbContext _context;
        private readonly IBase64FileConverter _fileConverter;
        public GetAllPostsQueryHandler(BlogDbContext context, IBase64FileConverter fileConverter)
        {
            _context = context;
            _fileConverter = fileConverter;
        }
        public async Task<GetAllPostsResponse> Handle(GetAllPostQuery request, CancellationToken cancellationToken)
        {
            var posts = await _context.Posts
                .Select(x => new PostDetailsDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    Content = x.Content,
                    AuthorId = x.Author.Id,
                    Image = _fileConverter.Write(x.Image.Image),
                    PublishedOn = x.PublishedOn
                })
                .ToListAsync(CancellationToken.None);

            return new GetAllPostsResponse
            {
                Posts = posts
            };
        }
    }
}
