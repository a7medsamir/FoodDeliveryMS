using FoodDelivery.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FoodDelivery.Data
{
    public interface IRestaurantData
    {

        IEnumerable<Restaurant> GetRestaurantByName(string Name);
        Restaurant GetRestaurantById(Guid restaurantId);
    }

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
    }
}
