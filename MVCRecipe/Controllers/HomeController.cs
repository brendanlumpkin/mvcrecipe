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

        //hard coded list for appearances sake
        List<ApplicationUser> userList = new List<ApplicationUser>
        {
                new ApplicationUser() {Name = "Brendan Lumpkin", Id = "1", Email = "lumpkinbrendan@gmail.com", PhoneNumber = "202-555-5555", City = "Washington, D.C.", State = "n/a"},
                new ApplicationUser() {Name = "Erin Jacobs", Id = "2", Email = "emjacobs2@crimson.ua.edu", PhoneNumber = "205-555-5555", City = "Tuscaloosa", State = "AL" },
                new ApplicationUser() {Name = "Hunter Esposito", Id = "3", Email = "hesposito@ua.edu", PhoneNumber = "718-917-2121", City = "New York", State = "NY" },
                new ApplicationUser() {Name = "Test Admin", Id = "4", Email = "admin@ua.edu", PhoneNumber = "205-205-2052", City = "Tuscaloosa", State = "AL" },
        };

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
            List<Recipe> recipes = _context.Recipe
                .Where(u => u.ApplicationUserId == user.Id)
                .ToList();
            return View(recipes);
        }

        //beginning of admin controllers
        public IActionResult Admin()
        {
            List<ApplicationUser> users = _context.ApplicationUser.ToList();
            //return View(users);
            return View(userList);
        }

        [HttpPost]
        public IActionResult Admin(List<ApplicationUser> users)
        {
            //List<ApplicationUser> users = _context.ApplicationUser.ToList();
            return View(users);
            //return View(userList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost] 
        public IActionResult Create(ApplicationUser user)
        {
            userList.Add(user);
            userList.Append(user);
            //_context.Add(user); <-- add new user to the db
            return RedirectToAction("Admin", userList);
        }

        public IActionResult Edit(string id)
        {
            var user = userList.Where(u => u.Id == id).FirstOrDefault();
            return View(user);
        }
        [HttpPost]
        public IActionResult Edit(ApplicationUser user)
        {
            ApplicationUser temp = userList.Where(u => u.Id == user.Id).FirstOrDefault();
            temp.Name = user.Name;
            temp.Email = user.Email;
            temp.City = user.City;
            temp.State = user.State;
            temp.PhoneNumber = user.PhoneNumber;
            userList.Append(temp);
            //_context.Update(temp); <-- update user in db
            return RedirectToAction("Admin", userList);
        }

        public IActionResult Delete(string id)
        {
            ApplicationUser user = userList.Where(u => u.Id == id).FirstOrDefault();
            userList.Remove(user);
            //_context.Remove(user); <-- remove user from db
            return RedirectToAction("Admin", userList);
        }

        //end of admin controllers

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<ActionResult> SaveRecipe(string link)
        {
            var user = await _userManager.GetUserAsync(User);
            Recipe recipe = new Recipe
            {
                ApplicationUserId = user.Id,
                RecipeLink = link,
            };
            _context.Add(recipe);
            _context.SaveChanges();
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
