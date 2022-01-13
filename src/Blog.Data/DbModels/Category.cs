using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Data.DbModels
{
    public class Category
    {
        public Category()
        {
            Posts = new HashSet<Post>();
        }

        [Key]
        [Column("id")]
        public Guid Id { get; set; }
        
        [Column("name")]
        public string Name { get; set; }

        public virtual IEnumerable<Post> Posts { get; set; }
    }
}
