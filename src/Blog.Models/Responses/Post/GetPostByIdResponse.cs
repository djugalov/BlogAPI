using Blog.Models.Abstractions;
using Blog.Models.DTOs.Post;

namespace Blog.Models.Responses.Post
{
    public class GetPostByIdResponse : BaseResponse
    {
        public PostDetailsDto Post { get; set; }
    }
}
