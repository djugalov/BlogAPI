using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Data.DbModels
{
    public class User
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("username")]
        public string Username { get; set; }
    }
}