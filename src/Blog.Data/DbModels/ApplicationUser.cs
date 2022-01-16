using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Data.DbModels
{
    public class ApplicationUser
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("username")]
        public string Username { get; set; }

        [Column("first_name")]
        public string FirstName { get; set; }

        [Column("middle_name")]
        public string MiddleName { get; set; }

        [Column("last_name")]
        public string LastName { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [Column("role")]
        public string Role { get; set; } = string.Empty;

        [ForeignKey("author_user_id")]
        public virtual User AuthorUser { get; set; }
    }
}
