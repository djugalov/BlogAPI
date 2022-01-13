using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Data.DbModels
{
    public class Comment
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [ForeignKey("author_id")]
        public User Author { get; set; }

        [Column("content")]
        public string Content { get; set; }

        [Column("upvotes")]
        public int Upvotes { get; set; }

        [Column("downvotes")]
        public int Downvotes { get; set; }
    }
}