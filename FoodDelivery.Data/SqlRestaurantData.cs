using FoodDelivery.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
namespace FoodDelivery.Data
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly FoodDeliveryDbContext db;

        public SqlRestaurantData(FoodDeliveryDbContext db)
        {
            this.db = db;
        }
        public Restaurant AddRestaurant(Restaurant restaurant)
        {
            db.Add(restaurant);
            return restaurant;

        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public Restaurant DeleteRestaurant(Guid restaurantId)
        {
            var restaurantToRemove = GetRestaurantById(restaurantId);
            if (restaurantToRemove != null)
            {
                db.Restaurants.Remove(restaurantToRemove);
            }
            return restaurantToRemove;
        }

        public Restaurant GetRestaurantById(Guid restaurantId)
        {
            return db.Restaurants.Find(restaurantId);
        }

        public IEnumerable<Restaurant> GetRestaurantByName(string Name)
        {
            var query = from r in db.Restaurants
                        where r.Name.StartsWith(Name) || string.IsNullOrWhiteSpace(Name)
                        orderby r.Name
                        select r;
            return query;
        }

        public Restaurant UpdateRestaurant(Restaurant restaurant)
        {
            var entity = db.Restaurants.Attach(restaurant);
            entity.State = EntityState.Modified;
            return restaurant;
        }
    }
}
