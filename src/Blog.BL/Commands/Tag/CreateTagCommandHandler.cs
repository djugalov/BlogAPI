using Blog.Data;
using Blog.Models.Responses.Tag;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.BL.Commands.Tag
{
    public class CreateTagCommandHandler : IRequestHandler<CreateTagCommand, CreateTagResponse>
    {
        private readonly BlogDbContext _context;

        public CreateTagCommandHandler(BlogDbContext context)
        {
            _context = context;
        }
        public async Task<CreateTagResponse> Handle(CreateTagCommand createTagCommand, CancellationToken cancellationToken)
        {
            var tag = await _context.AddAsync(new Data.DbModels.Tag
            {
                Name = createTagCommand.Request.Tag.Name
            }, CancellationToken.None);

            await _context.SaveChangesAsync(CancellationToken.None);

            return new CreateTagResponse
            {
                IsSuccess = true,
                ResponseMessage = "Tag was added successfully",
                Tag = new Models.DTOs.Tag.TagDetailsDto
                {
                    Id = tag.Entity.Id,
                    Name = tag.Entity.Name
                }
            };
        }
    }
}
