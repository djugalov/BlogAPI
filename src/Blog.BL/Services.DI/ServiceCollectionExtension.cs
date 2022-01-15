using Blog.BL.Commands.Category;
using Blog.BL.Commands.Post;
using Blog.BL.Helpers;
using Blog.BL.Queries.Category;
using Blog.BL.Queries.Post;
using Blog.Models.Responses.Category;
using Blog.Models.Responses.Post;
using MediatR;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddProjectServices(this IServiceCollection services)
        {
            AddCategoryServices(services);

            AddPostServices(services);

            AddHelperServices(services);

            return services;
        }

        private static void AddCategoryServices(IServiceCollection services)
        {
            services.AddTransient<IRequestHandler<AddCategoryCommand, AddCategoryResponse>, AddCategoryCommandHandler>();
            services.AddTransient<IRequestHandler<DeleteCategoryCommand, DeleteCategoryResponse>, DeleteCategoryCommandHandler>();
            services.AddTransient<IRequestHandler<EditCategoryCommand, EditCategoryResponse>, EditCategoryCommandHandler>();
            services.AddTransient<IRequestHandler<GetCategoryByIdQuery, GetCategoryByIdResponse>, GetCategoryByIdQueryHandler>();
            services.AddTransient<IRequestHandler<GetAllCategoriesQuery, GetAllCategoriesResponse>, GetAllCategoriesQueryHandler>();
        }

        private static void AddPostServices(IServiceCollection services)
        {
            services.AddTransient<IRequestHandler<CreatePostCommand, CreatePostResponse>, CreatePostCommandHandler>();
            services.AddTransient<IRequestHandler<DeletePostCommand, DeletePostResponse>, DeletePostCommandHandler>();
            services.AddTransient<IRequestHandler<GetPostByIdQuery, GetPostByIdResponse>, GetPostByIdQueryHandler>();
            services.AddTransient<IRequestHandler<GetAllPostQuery, GetAllPostsResponse>, GetAllPostsQueryHandler>();
        }

        private static void AddHelperServices(IServiceCollection services)
        {
            services.AddTransient<IBase64FileConverter, Base64FileConverter>();
        }
    }
}
