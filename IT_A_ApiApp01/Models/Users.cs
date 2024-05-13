using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IT_A_ApiApp01.Models
{
    public class Users
    {
        [Key] // Mark Id property as the primary key
        public int Id { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [Index(IsUnique = true)]
        [Column(TypeName = "nvarchar")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        [Index(IsUnique = true)]
        [Column(TypeName = "nvarchar")]
        public string Email { get; set; }


        [Column(TypeName = "nvarchar")]
        public string Password { get; set; }

        public Blog[] Blogs;    
    }
}