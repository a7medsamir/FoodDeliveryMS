using FoodDelivery.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDelivery.ViewComponents
{
    public class RestaurantsCountViewComponent : ViewComponent
    {
        private readonly IRestaurantData restaurantData;

        public RestaurantsCountViewComponent(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }
        public IViewComponentResult Invoke()
        {
            int count = restaurantData.GetCountOfRestaurants();

            return View(count);
        }
    }
}
