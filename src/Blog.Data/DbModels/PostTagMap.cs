using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Data.DbModels
{
    public class PostTagMap
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [ForeignKey("post_id")]
        public virtual Post Post { get; set; }

        [ForeignKey("tag_id")]
        public virtual Tag Tag { get; set; }
    }
}