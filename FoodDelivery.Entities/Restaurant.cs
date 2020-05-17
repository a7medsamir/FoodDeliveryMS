using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FoodDelivery.Entities
{

    public class Restaurant
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public CuisineTypes Cuisine { get; set; }

        /*
        public double Lat { get; set; }
        public double Long { get; set; }

        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public string WebSiteUrl { get; set; }

        public TimeSpan OpenTime { get; set; }
        public TimeSpan CloseTime { get; set; }

        public bool IsActive { get; set; }*/
    }
}


