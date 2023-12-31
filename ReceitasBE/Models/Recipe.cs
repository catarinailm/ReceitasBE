﻿using System.ComponentModel.DataAnnotations;

namespace ReceitasBE.Models
{
    public class Recipe
    {
        [Key]
        public Guid Id { get; set; }
        public User User { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public int Difficulty { get; set; }
        public string Procedure { get; set; }
        public bool Approved { get; set; }
        public bool Deleted { get; set; }
        public string Image_name { get; set; }
        public DateTime Data_created { get; set; }
        public DateTime Data_updated { get; set; }
        public DateTime Data_deleted { get; set; }
        public List<Ingredient> Ingredients { get; set;}
        public ICollection<Rating> Ratings { get; set; }
        public List<RecipeCategory> RecipeCategories { get; }
    }
}
