using Blog.BL.Helpers;
using Blog.Data;
using Blog.Models.Responses.Post;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.BL.Commands.Post
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, CreatePostResponse>
    {
        private readonly BlogDbContext _context;
        private readonly IBase64FileConverter _fileConverter;
        public CreatePostCommandHandler(BlogDbContext context, IBase64FileConverter fileConverter)
        {
            _context = context;
            _fileConverter = fileConverter;
        }
        public async Task<CreatePostResponse> Handle(CreatePostCommand createPostCommand, CancellationToken cancellationToken)
        {
            var author = await _context.Users.FindAsync(new object[] { createPostCommand.Request.Post.AuthorId }, CancellationToken.None);

            if(author == null)
            {
                return new CreatePostResponse
                {
                    IsSuccess = false,
                    ResponseMessage = $"Post was not added, because author with the given id {createPostCommand.Request.Post.AuthorId} does not exist"
                };
            }

            var post = new Blog.Data.DbModels.Post
            {
                Title = createPostCommand.Request.Post.Title,
                Content = createPostCommand.Request.Post.Content,
                Image = new Data.DbModels.PostImage
                {
                    Image = _fileConverter.Read(createPostCommand.Request.Post.Image)
                },
                Author = author,
                PublishedOn = DateTime.UtcNow
            };

            var createdPost = await _context.Posts.AddAsync(post, CancellationToken.None);

            await _context.SaveChangesAsync(CancellationToken.None);

            return new CreatePostResponse
            {
                Id = createdPost.Entity.Id,
                Post = new Models.DTOs.Post.CreatePostDto
                {
                    Title = createdPost.Entity.Title,
                    Content = createdPost.Entity.Content,
                    AuthorId = createdPost.Entity.Author.Id,
                    Image = createPostCommand.Request.Post.Image
                },
                IsSuccess = true,
                ResponseMessage = "Post was added successfully"
            };
        }
    }
}
