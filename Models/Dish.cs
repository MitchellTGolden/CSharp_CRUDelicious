using System;
using System.ComponentModel.DataAnnotations;

namespace CRUDelicious.Models
{
    public class Dish
    {
        [Key]
        public int DishId { get; set; }
        [Required]
        [Display(Name = "Chef's Name:")]

        public string ChefName { get; set; }
        [Required]
        [Display(Name = "Name of the Dish:")]

        public string DishName { get; set; }
        [Required]
        [Range(0, Int32.MaxValue)]
        [Display(Name = "Calories:")]
        public int NumCalories { get; set; }
        [Required]
        [Range(1, 5)]
        [Display(Name = "Tastiness:")]
        public int Tastiness { get; set; }
        [Display(Name = "Description:")]
        [Required]
        public string Desc { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}