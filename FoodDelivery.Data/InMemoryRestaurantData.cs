using FoodDelivery.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodDelivery.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>() {
                new Restaurant() {
                    Id = Guid.NewGuid(), Name="Mandi Reef", Cuisine= CuisineTypes.Arabic, Address="Grand Mall ,Muscat" } ,
                new Restaurant() {
                    Id = Guid.NewGuid(), Name="Macdonalds", Cuisine= CuisineTypes.Western, Address="Avenuz Mall ,Muscat" } ,
                new Restaurant() {
                    Id = Guid.NewGuid(), Name="KFC", Cuisine= CuisineTypes.Western, Address="Avenuz Mall ,Muscat" } ,
                new Restaurant() {
                    Id = Guid.NewGuid(), Name="Sweet And Spice", Cuisine= CuisineTypes.Indian, Address="Avenuz Mall ,Muscat" } ,
            };
        }

        public Restaurant AddRestaurant(Restaurant restaurant)
        {
            restaurants.Add(restaurant);
            restaurant.Id = Guid.NewGuid();
            return restaurant;
        }

        public int Commit()
        {
            return 0;
        }

        public Restaurant DeleteRestaurant(Guid restaurantId)
        {
            var restaurantToRemove = GetRestaurantById(restaurantId);
            if (restaurantToRemove != null)
            {
                restaurants.Remove(restaurantToRemove);                
            }
            return restaurantToRemove;
        }

        public Restaurant GetRestaurantById(Guid restaurantId)
        {
            return restaurants.SingleOrDefault(r => r.Id == restaurantId);
        }

        public IEnumerable<Restaurant> GetRestaurantByName(string Name = null)
        {
            return from r in restaurants
                   where String.IsNullOrWhiteSpace(Name) || r.Name.StartsWith(Name)
                   orderby r.Name
                   select r;
        }

        public Restaurant UpdateRestaurant(Restaurant updatedRestaurant)
        {
            var restaurant = GetRestaurantById(updatedRestaurant.Id);
            if (restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Address = updatedRestaurant.Address;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
            }
            return restaurant;
        }
    }
}
