using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodDelivery.Data;
using FoodDelivery.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.Extensions.Configuration;

namespace FoodDelivery.Pages.Restaurants
{
    public class IndexModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IRestaurantData restaurantData;
        public IEnumerable<Restaurant> Restaurants { get; set; }
        public string Message { get; set; }
        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }
        public IndexModel(IConfiguration config, IRestaurantData restaurantData)
        {
            this.config = config;
            this.restaurantData = restaurantData;
        }
     
        public void OnGet()
        {
            Restaurants = restaurantData.GetRestaurantByName(SearchTerm);
            Message = config["Message"];
        }
        public IActionResult OnPostDelete(Guid restaurantId)
        {
            var result= restaurantData.DeleteRestaurant(restaurantId);
            restaurantData.Commit();
            Restaurants = restaurantData.GetRestaurantByName(SearchTerm);
            TempData["Message"] = "Restaurant Deleted Successfully!";
            return RedirectToPage("./Index");
        }
    }
}
