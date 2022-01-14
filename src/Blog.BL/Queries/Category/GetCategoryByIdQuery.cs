using Blog.Models.Responses.Category;
using MediatR;
using System;

namespace Blog.BL.Queries.Category
{
    public class GetCategoryByIdQuery : IRequest<GetCategoryByIdResponse>
    {
        public GetCategoryByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
