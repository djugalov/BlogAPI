using Blog.BL.Commands.Category;
using Blog.BL.Queries.Category;
using Blog.Models.Responses.Category;
using MediatR;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddProjectServices(this IServiceCollection services)
        {
            services.AddTransient<IRequestHandler<AddCategoryCommand, AddCategoryResponse>, AddCategoryCommandHandler>();
            services.AddTransient<IRequestHandler<DeleteCategoryCommand, DeleteCategoryResponse>, DeleteCategoryCommandHandler>();
            services.AddTransient<IRequestHandler<EditCategoryCommand, EditCategoryResponse>, EditCategoryCommandHandler>();
            services.AddTransient<IRequestHandler<GetCategoryByIdQuery, GetCategoryByIdResponse>, GetCategoryByIdQueryHandler>();
            services.AddTransient<IRequestHandler<GetAllCategoriesQuery, GetAllCategoriesResponse>, GetAllCategoriesQueryHandler>();

            return services;
        }
    }
}
