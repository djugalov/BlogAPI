using System;
using System.ComponentModel.DataAnnotations;

namespace Blog.Models.Requests.Tag
{
    public class DeleteTagRequest
    {
        [Required(ErrorMessage = "Tag Id must be provided")]
        public Guid Id { get; set; }
    }
}
