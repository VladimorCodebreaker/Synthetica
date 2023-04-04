using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Synthetica.Data.Base;
using Synthetica.Data.Enums;

namespace Synthetica.Models
{
    public class Drug : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Image")]
        [Required(ErrorMessage = "Image is required!")]
        public string Image { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required!")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Name must be between 1 - 100 characters long!")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Description is required!")]
        public string Description { get; set; }

        public double Price { get; set; }

        [Display(Name = "Drug Category")]
        [Required(ErrorMessage = "Drug Category is required!")]
        public DrugCategory DrugCategory { get; set; }

        // Relationships
        public IList<Substance_Drug> Substance_Drugs { get; set; }

        public int PharmacyId { get; set; }
        [ForeignKey("PharmacyId")]
        public Pharmacy Pharmacy { get; set; }

        public int ProducerId { get; set; }
        [ForeignKey("ProducerId")]
        public Producer Producer { get; set; }
    }
}

