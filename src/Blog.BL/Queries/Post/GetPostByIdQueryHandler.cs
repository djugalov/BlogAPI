using Blog.BL.Helpers;
using Blog.Data;
using Blog.Models.Responses.Post;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.BL.Queries.Post
{
    public class GetPostByIdQueryHandler : IRequestHandler<GetPostByIdQuery, GetPostByIdResponse>
    {
        private readonly BlogDbContext _context;
        private readonly IBase64FileConverter _fileConverter;
        public GetPostByIdQueryHandler(BlogDbContext context, IBase64FileConverter fileConverter)
        {
            _context = context;
            _fileConverter = fileConverter;
        }
        public async Task<GetPostByIdResponse> Handle(GetPostByIdQuery query, CancellationToken cancellationToken)
        {
            var post = await _context.Posts
                .Include(x => x.Image)
                .Include(x => x.Author)
                .FirstOrDefaultAsync(x => x.Id == query.Request.Id, CancellationToken.None);

            if (post == null)
            {
                return new GetPostByIdResponse
                {
                    IsSuccess = false,
                    ResponseMessage = $"Post with the given id {query.Request.Id} does not exist"
                };
            }

            return new GetPostByIdResponse
            {
                IsSuccess = true,
                ResponseMessage = "Getting of post was successful",
                Post = new Models.DTOs.Post.PostDetailsDto
                {
                    Id = post.Id,
                    Title = post.Title,
                    Content = post.Content,
                    AuthorId = post.Author.Id,
                    Image = _fileConverter.Write(post.Image.Image)
                }
            };
        }
    }
}
