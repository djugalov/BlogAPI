using Blog.Models.Abstractions;
using Blog.Models.DTOs.Tag;
using System.Collections.Generic;

namespace Blog.Models.Responses.Tag
{
    public class GetAllTagsPerPostResponse : BaseResponse
    {
        public IEnumerable<TagDetailsDto> Tags { get; set; }
    }
}
