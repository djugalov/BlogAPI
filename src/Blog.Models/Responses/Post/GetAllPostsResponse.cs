using Blog.Models.DTOs.Post;
using System.Collections.Generic;

namespace Blog.Models.Responses.Post
{
    public class GetAllPostsResponse
    {
        public IEnumerable<PostDetailsDto> Posts { get; set; }
    }
}
