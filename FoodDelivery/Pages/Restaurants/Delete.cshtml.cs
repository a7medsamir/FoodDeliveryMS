using System;
using FoodDelivery.Data;
using FoodDelivery.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodDelivery.Pages.Restaurants
{
    public class DeleteModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        public Restaurant Restaurant { get; set; }
        public DeleteModel( IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }
        public IActionResult OnGet(Guid? restaurantId)
        {
            if (restaurantId.HasValue)
            {
                this.Restaurant = restaurantData.GetRestaurantById(restaurantId.Value);
            }
            if (this.Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost(Guid restaurantId)
        {
            var result = restaurantData.DeleteRestaurant(restaurantId);
            restaurantData.Commit();

            if (result == null)
            {
                return RedirectToPage("./NotFound");
            }

            TempData["Message"] = $"Restaurant {result.Name} Deleted Successfully!";
            return RedirectToPage("./Index");
        }
    }
}