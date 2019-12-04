﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MVCRecipe.Models
{
    public class Recipe
    {
        public int RecipeId { get; set; }
        public string RecipeLink { get; set; }
        public ApplicationUser User { get; set; }
    }
}
