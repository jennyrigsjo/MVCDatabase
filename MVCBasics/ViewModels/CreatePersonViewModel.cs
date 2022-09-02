using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCBasics.Models;

namespace MVCBasics.ViewModels
{
    public class CreatePersonViewModel
    {
        [Required]
        [Display(Name = "First and last name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Telephone number")]
        public string Phone { get; set; } = string.Empty;

        [Required]
        [Display(Name = "City of residence")]
        public string City { get; set; } = string.Empty;

        public SelectList? SelectCity { get; set; }
    }
}
