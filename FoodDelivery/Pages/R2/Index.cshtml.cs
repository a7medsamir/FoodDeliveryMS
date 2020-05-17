using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FoodDelivery.Data;
using FoodDelivery.Entities;

namespace FoodDelivery.Pages.R2
{
    public class IndexModel : PageModel
    {
        private readonly FoodDelivery.Data.FoodDeliveryDbContext _context;

        public IndexModel(FoodDelivery.Data.FoodDeliveryDbContext context)
        {
            _context = context;
        }

        public IList<Restaurant> Restaurant { get;set; }

        public async Task OnGetAsync()
        {
            Restaurant = await _context.Restaurants.ToListAsync();
        }
    }
}
