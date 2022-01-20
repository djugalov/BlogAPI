using Blog.Models.Abstractions;
using System;

namespace Blog.Models.Responses.Category
{
    public class AddCategoryResponse : BaseResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
