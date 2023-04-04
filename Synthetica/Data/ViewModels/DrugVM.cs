using System;
using Synthetica.Data.Enums;
using System.ComponentModel.DataAnnotations;
using Synthetica.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Synthetica.Data.ViewModels
{
    public class DrugVM
    {
        public int Id { get; set; }

        [Display(Name = "Drug Image URL")]
        [Required(ErrorMessage = "Image URL is required!")]
        public string Image { get; set; }

        [Display(Name = "Drug Name")]
        [Required(ErrorMessage = "Name is required!")]
        public string Name { get; set; }

        [Display(Name = "Drug Description")]
        [Required(ErrorMessage = "Description is required!")]
        public string Description { get; set; }

        [Display(Name = "Price in €")]
        [Required(ErrorMessage = "Price is required!")]
        public double Price { get; set; }

        [Display(Name = "Select a Category")]
        [Required(ErrorMessage = "Drug Category is required!")]
        public DrugCategory DrugCategory { get; set; }

        //Relationships
        [Display(Name = "Select Substance(s)")]
        [Required(ErrorMessage = "Drug Substance(s) is / are required!")]
        public IList<int> SubstanceIds { get; set; }

        [Display(Name = "Select a Pharmacy")]
        [Required(ErrorMessage = "Drug Pharmacy is required!")]
        public int PharmacyId { get; set; }

        [Display(Name = "Select a Producer")]
        [Required(ErrorMessage = "Drug Producer is required!")]
        public int ProducerId { get; set; }
    }
}

