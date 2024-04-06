using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IT_A_ApiApp01.Models
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [Index(IsUnique = true)]
        [Column(TypeName = "nvarchar")]
        [MaxLength(255)] // Maximum length annotation for Title
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [Index(IsUnique = true)]
        [Column(TypeName = "nvarchar")]
        [MaxLength(1000)] // Maximum length annotation for Title
        public string Description { get; set; }
    }
}