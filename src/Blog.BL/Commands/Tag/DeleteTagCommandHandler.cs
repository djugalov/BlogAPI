using Blog.Data;
using Blog.Models.DTOs.Tag;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.BL.Commands.Tag
{
    public class DeleteTagCommandHandler : IRequestHandler<DeleteTagCommand, DeleteTagResponse>
    {
        private readonly BlogDbContext _context;
        public DeleteTagCommandHandler(BlogDbContext context)
        {
            _context = context;
        }

        public async Task<DeleteTagResponse> Handle(DeleteTagCommand command, CancellationToken cancellationToken)
        {
            var tag = await _context.Tags.FirstOrDefaultAsync(x => x.Id == command.Request.Id, CancellationToken.None);

            if(tag == null)
            {
                return new DeleteTagResponse
                {
                    IsSuccess = false,
                    ResponseMessage = $"Tag with the given id {command.Request.Id} does not exist"
                };
            }

            _context.Tags.Remove(tag);

            await _context.SaveChangesAsync(CancellationToken.None);

            return new DeleteTagResponse
            {
                IsSuccess = true,
                ResponseMessage = "Tag was deleted successfully"
            };
        }
    }
}
