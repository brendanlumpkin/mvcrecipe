using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCRecipe.Data;
using MVCRecipe.Models;

namespace MVCRecipe.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, UserManager<IdentityUser> userManager, ApplicationDbContext context)
        {
            _logger = logger;
            _userManager = userManager;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Categories()
        {
            return View();
        }
        public async Task<IActionResult> Favorites()
        {
            var user = await _userManager.GetUserAsync(User);
            var temp = _context.ApplicationUser.Where(u => u.Id == user.Id).FirstOrDefault();
            List<Recipe> recipes = temp.Recipes.ToList();
            return View(recipes);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<ActionResult> SaveRecipe(string link)
        {
            var user = await _userManager.GetUserAsync(User);
            var temp = _context.ApplicationUser.Where(u => u.Id == user.Id).FirstOrDefault();
            var recipe = new Recipe
            {
                User = temp,
                RecipeLink = link,
            };
            _context.Add(recipe);
            await _context.SaveChangesAsync();
            return View("Index");
        }

        public async Task<ActionResult> GetRecipes()
        {
            var user = await _userManager.GetUserAsync(User);
            var temp = _context.ApplicationUser.Where(u => u.Id == user.Id).FirstOrDefault();
            List<Recipe> recipes = temp.Recipes.ToList();
            return View(recipes);
        }
    }
}
