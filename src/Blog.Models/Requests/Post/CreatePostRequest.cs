using Blog.Models.DTOs.Post;
using System.ComponentModel.DataAnnotations;

namespace Blog.Models.Requests.Post
{
    public class CreatePostRequest
    {
        public CreatePostRequest(CreatePostDto post)
        {
            Post = post;
        }

        [Required(ErrorMessage = "Information about new post must be provided")]
        public CreatePostDto Post { get; set; }
    }
}
