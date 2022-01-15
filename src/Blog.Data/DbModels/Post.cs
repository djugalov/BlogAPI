using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Data.DbModels
{
    public class Post
    {
        public Post()
        {
            Comments = new HashSet<Comment>();
            Tags = new HashSet<PostTagMap>();
            Categories = new HashSet<CategoryPostMap>();
        }

        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("title")]
        public string Title { get; set; }

        [MaxLength]
        [Column("content")]
        public string Content { get; set; }

        [Column("published_on")]
        public DateTime PublishedOn { get; set; }

        [ForeignKey("author_id")]
        public User Author { get; set; }

        [Column("upvotes")]
        public int Upvotes { get; set; }

        [Column("downvotes")]
        public int Downvotes { get; set; }

        [Column("is_deleted")]
        public bool IsDeleted { get; set; }

        public virtual IEnumerable<Comment> Comments { get; set; }
        
        public virtual IEnumerable<PostTagMap> Tags { get; set; }

        public virtual IEnumerable<CategoryPostMap> Categories { get; set; }
    }
}
