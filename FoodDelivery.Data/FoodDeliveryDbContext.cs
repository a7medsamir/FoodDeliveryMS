using FoodDelivery.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodDelivery.Data
{
    public class FoodDeliveryDbContext : DbContext
    {
        public FoodDeliveryDbContext(DbContextOptions<FoodDeliveryDbContext> options): base(options)
        {

        }
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
