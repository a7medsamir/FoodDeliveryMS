using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodDelivery.Data;
using FoodDelivery.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FoodDelivery.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        private readonly IHtmlHelper htmlHelper;

        [BindProperty]
        public Restaurant Restaurant { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }

        public EditModel(IRestaurantData restaurantData, IHtmlHelper htmlHelper)
        {
            this.restaurantData = restaurantData;
            this.htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(Guid? restaurantId)
        {
            this.Cuisines = htmlHelper.GetEnumSelectList<CuisineTypes>();
            if (restaurantId.HasValue)
            {
                this.Restaurant = restaurantData.GetRestaurantById(restaurantId.Value);
            }
            else
            {
                this.Restaurant = new Restaurant();
            }


            if (this.Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                this.Cuisines = htmlHelper.GetEnumSelectList<CuisineTypes>();
                return Page();
            }
            string outputMessage;
            if (this.Restaurant.Id != null && this.Restaurant.Id != Guid.Empty)
            {
                this.Restaurant = restaurantData.UpdateRestaurant(this.Restaurant);
                outputMessage = "Restaurant Updated Successfully!";
            }
            else
            {
                this.Restaurant = restaurantData.AddRestaurant(this.Restaurant);
                outputMessage = "Restaurant Added Successfully!";
            }

            restaurantData.Commit();
            TempData["Message"] = outputMessage;
            return RedirectToPage("./Detail", new { restaurantId = Restaurant.Id });
        }
    }
}