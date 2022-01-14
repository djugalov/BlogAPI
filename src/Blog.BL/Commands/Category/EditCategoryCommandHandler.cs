using Blog.Data;
using Blog.Models.Responses.Category;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.BL.Commands.Category
{
    public class EditCategoryCommandHandler : IRequestHandler<EditCategoryCommand, EditCategoryResponse>
    {
        private readonly BlogDbContext _context;

        public EditCategoryCommandHandler(BlogDbContext context)
        {
            _context = context;
        }

        public async Task<EditCategoryResponse> Handle(EditCategoryCommand editCategoryCommand, CancellationToken cancellationToken)
        {
            var category = await _context.Categories.FindAsync(editCategoryCommand.Category.Id);

            if(category == null)
            {
                return new EditCategoryResponse
                {
                    IsSuccess = false,
                    EditCategoryResponseMessage = $"Category with the given id {editCategoryCommand.Category.Id} does not exist"
                };
            }

            category.Name = editCategoryCommand.Category.Name;

            await _context.SaveChangesAsync();

            return new EditCategoryResponse
            {
                IsSuccess = true,
                EditCategoryResponseMessage = "Category was edited successfully",
                Category = new Models.DTOs.Category.BaseCategoryDto
                {
                    Id = category.Id,
                    Name = category.Name
                }
            };
        }
    }
}
