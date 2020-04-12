using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp1.Data;

namespace WebApp1.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new WebApp1Context(
                serviceProvider.GetRequiredService<DbContextOptions<WebApp1Context>>()))
            {
                //look for any player info
                if (context.Bikers.Any())
                {
                    //DB already seeded
                    return;
                }

                context.Bikers.AddRange(

                    new Bikers
                    {
                        BikerName = "Steve Peat",
                        BikerSponsor = "Monster Eneregy Drink",
                        BikerCarreerWinnings = 5000000,
                        BikerLink = "https://www.youtube.com/watch?v=wnDjC0Y-znc"
                    },

                    new Bikers
                    {
                        BikerName = "Yoann Barelli",
                        BikerSponsor = "Dakine",
                        BikerCarreerWinnings = 3500000,
                        BikerLink = "https://www.youtube.com/watch?v=i8nJIUrX1vU"
                    },

                    new Bikers
                    {
                        BikerName = "Tom Van Steenbergen",
                        BikerSponsor = "Red Bull",
                        BikerCarreerWinnings = 1700000,
                        BikerLink = "https://www.youtube.com/watch?v=u7a3jrhhVUM"
                    }
                    );

                context.SaveChanges();
            }
        }
    }
}
