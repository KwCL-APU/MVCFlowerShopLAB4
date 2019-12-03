using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MVCFlowerShop.Models
{
    public class SeedData
    {
        public static void Initialize (IServiceProvider serviceProvider)
        {
            //var context used for storing the db connection
            using (var context = new MVCFlowerShopContext(
                serviceProvider.GetRequiredService<DbContextOptions<MVCFlowerShopContext>>()))
            {
                //check the db table have any data or not
                //if not, add the new dummy data into the table
                if(context.Flower.Any())
                {
                    return; // means this is old table, no need to add new dummy data, so return
                }

                //otherwise, means this is new table / database, so need to add new dummy data
                context.Flower.AddRange(
                    //add the flower information here
                    new Flower
                    {
                        FlowerName = "Chrysanthemum",
                        FlowerProducedDate = DateTime.Parse("2018-2-12"),
                        Type = "Asteraceace",
                        Price = 5.67M,
                        Rating = "3.5"
                    },
                    new Flower
                    {
                        FlowerName = "Arum-lily",
                        FlowerProducedDate = DateTime.Parse("2018-3-28"),
                        Type = "Araceae",
                        Price = 5.67M,
                        Rating = "4.0"
                    }
                );
                context.SaveChanges(); //must include, otherwise no changes will be done!
            }
        }
    }
}
