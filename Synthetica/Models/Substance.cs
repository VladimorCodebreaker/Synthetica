using System;
using System.ComponentModel.DataAnnotations;
using Synthetica.Data.Base;

namespace Synthetica.Models
{
    public class Substance : IEntityBase
    {
        [Key]
        public int Id { get; set; }


        [Display(Name = "Image")]
        [Required(ErrorMessage = "Image is required!")]
        public string Image { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required!")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Name must be 1 - 100 characters long!")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Description is required!")]
        public string Description { get; set; }

        // Relationships
        public IList<Substance_Drug> Substance_Drugs { get; set; }
    }
}

