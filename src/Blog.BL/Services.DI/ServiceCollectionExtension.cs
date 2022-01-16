using Blog.BL.Authorization;
using Blog.BL.Authorization.Contracts;
using Blog.BL.Commands.ApplicationUser;
using Blog.BL.Commands.Category;
using Blog.BL.Commands.Comment;
using Blog.BL.Commands.Post;
using Blog.BL.Helpers;
using Blog.BL.Queries.Category;
using Blog.BL.Queries.Post;
using Blog.Models.Requests.Post;
using Blog.Models.Responses.ApplicationUser;
using Blog.Models.Responses.Category;
using Blog.Models.Responses.Comment;
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

            AddApplicationUserServices(services);

            AddAutorizationServices(services);

            AddCommentServices(services);

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

        private static void AddApplicationUserServices(IServiceCollection services)
        {
            services.AddTransient<IRequestHandler<RegisterUserCommand, RegisterUserResponse>, RegisterUserCommandHandler>();
            services.AddTransient<IRequestHandler<LoginUserCommand, LoginUserResponse>, LoginUserCommandHandler>();
        }

        private static void AddAutorizationServices(IServiceCollection services)
        {
            services.AddTransient<IJwtTokenProvider, JwtTokenProvider>();
        }

        private static void AddCommentServices(IServiceCollection services)
        {
            services.AddTransient<IRequestHandler<CreateCommentCommand, CreateCommentResponse>, CreateCommentCommandHandler>();
            services.AddTransient<IRequestHandler<DeleteCommentCommand, DeleteCommentResponse>, DeleteCommentCommandHandler>();
            services.AddTransient<IRequestHandler<EditCommentCommand, EditCommentResponse>, EditCommentCommandHandler>();
        }
    }
}
