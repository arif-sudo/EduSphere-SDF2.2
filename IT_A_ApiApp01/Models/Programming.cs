using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IT_A_ApiApp01.Models
{
    public class Programming
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [Index(IsUnique = true)]
        [Column(TypeName = "nvarchar")]
        [MaxLength(255)] // Maximum length annotation for Title
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [Column(TypeName = "nvarchar")]
        [MaxLength(3000)] // Maximum length annotation for Title
        public string Description { get; set; }

        //Image
        [Required(ErrorMessage = "Image is required")]
        [Column(TypeName = "nvarchar")]
        [MaxLength(1000)] // Maximum length annotation for Title
        public string Image { get; set; }
    }
}