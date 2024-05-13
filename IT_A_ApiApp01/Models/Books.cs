using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IT_A_ApiApp01.Models
{
    public class Books
    {
        [Key]
        public int Id { get; set; }

        // Title
        [Required(ErrorMessage = "Title is required")]
        [Index(IsUnique = true)]
        [Column(TypeName = "nvarchar")]
        [MaxLength(255)] // Maximum length annotation for Title
        public string Title { get; set; }

        // Description
        [Required(ErrorMessage = "Description is required")]
        [Index(IsUnique = true)]
        [Column(TypeName = "nvarchar")]
        [MaxLength(1000)] // Maximum length annotation for Title
        public string Description { get; set; }

        //Author
        [Required(ErrorMessage = "Author is required")]
        [Index(IsUnique = false)]
        [Column(TypeName = "nvarchar")]
        [MaxLength(1000)] // Maximum length annotation for Title
        public string Author { get; set; }

        //Image
        [Required(ErrorMessage = "Image is required")]
        [Column(TypeName = "nvarchar")]
        [MaxLength(1000)] // Maximum length annotation for Title
        public string Image { get; set; }

        //Price
        [Required(ErrorMessage = "Price is required")]
        [Column(TypeName = "int")] 
        public int Price { get; set; }
    }
}
