using FoodDelivery.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodDelivery.Data
{
    public interface IRestaurantData
    {

        IEnumerable<Restaurant> GetRestaurantByName(string Name);
        Restaurant GetRestaurantById(Guid restaurantId);
        Restaurant UpdateRestaurant(Restaurant restaurant);
        int Commit();
        Restaurant AddRestaurant(Restaurant restaurant);
        Restaurant DeleteRestaurant(Guid restaurantId);
    }
}
