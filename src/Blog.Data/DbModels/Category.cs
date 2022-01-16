using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Data.DbModels
{
    [Index(nameof(Name), IsUnique = true)]
    public class Category
    {
        public Category()
        {
            Posts = new HashSet<CategoryPostMap>();
        }

        [Key]
        [Column("id")]
        public Guid Id { get; set; }
        
        [Column("name")]
        public string Name { get; set; }

        public virtual IEnumerable<CategoryPostMap> Posts { get; set; }
    }
}
