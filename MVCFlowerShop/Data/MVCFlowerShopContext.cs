using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MVCFlowerShop.Models
{
    public class MVCFlowerShopContext : DbContext
    {
        public MVCFlowerShopContext (DbContextOptions<MVCFlowerShopContext> options)
            : base(options)
        {
        }

        public DbSet<MVCFlowerShop.Models.Flower> Flower { get; set; }
    }
}
