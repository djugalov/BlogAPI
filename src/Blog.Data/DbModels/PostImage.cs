using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Data.DbModels
{
    public class PostImage
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [ForeignKey("post_id")]
        public virtual Post Post { get; set; }

        [Column("image")]
        public byte[] Image { get; set; }
    }
}
