﻿using Blog.Data;
using Blog.Models.Responses.Category;
using MediatR;
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
            var category = await _context.Categories.FindAsync(editCategoryCommand.Category.Id, CancellationToken.None);

            if(category == null)
            {
                return new EditCategoryResponse
                {
                    IsSuccess = false,
                    ResponseMessage = $"Category with the given id {editCategoryCommand.Category.Id} does not exist"
                };
            }

            category.Name = editCategoryCommand.Category.Name;

            await _context.SaveChangesAsync(CancellationToken.None);

            return new EditCategoryResponse
            {
                IsSuccess = true,
                ResponseMessage = "Category was edited successfully",
                Category = new Models.DTOs.Category.BaseCategoryDto
                {
                    Id = category.Id,
                    Name = category.Name
                }
            };
        }
    }
}
