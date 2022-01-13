using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Data.DbModels
{
    public class CategoryPostMap
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [ForeignKey("category_id")]
        public virtual Category Category { get; set; }

        [ForeignKey("post_id")]
        public virtual Post Post { get; set; }
    }
}
