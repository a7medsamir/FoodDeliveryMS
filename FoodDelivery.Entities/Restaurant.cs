using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FoodDelivery.Entities
{

    public class Restaurant
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required, StringLength(80)]
        public string Name { get; set; }
        [Required, StringLength(255)]
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


