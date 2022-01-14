using Blog.BL.Commands.Category;
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

            return services;
        }
    }
}
