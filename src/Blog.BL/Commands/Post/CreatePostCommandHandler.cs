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
        public CreatePostCommandHandler(BlogDbContext context)
        {
            _context = context;
        }
        public async Task<CreatePostResponse> Handle(CreatePostCommand createPostCommand, CancellationToken cancellationToken)
        {
            var author = await _context.Users.FindAsync(createPostCommand.Request.Post.AuthorId);

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
                Author = author,
                PublishedOn = DateTime.UtcNow
            };

            var createdPost = await _context.Posts.AddAsync(post);

            await _context.SaveChangesAsync();

            return new CreatePostResponse
            {
                Id = createdPost.Entity.Id,
                Post = new Models.DTOs.Post.CreatePostDto
                {
                    Title = createdPost.Entity.Title,
                    Content = createdPost.Entity.Content,
                    AuthorId = createdPost.Entity.Author.Id
                },
                IsSuccess = true,
                ResponseMessage = "Post was added successfully"
            };
        }
    }
}
