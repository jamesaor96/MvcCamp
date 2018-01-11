using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;



//Code below is based on "Create a web app with ASP.NET Core MVC using Visual Studio for Mac", www.microsoft.com, https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app-mac/
namespace MvcCamp.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcCampContext(
                serviceProvider.GetRequiredService<DbContextOptions<MvcCampContext>>()))
            {
                // Look for any movies.
                if (context.Camp.Any())
                {
                    return;   // DB has been seeded
                }

                context.Camp.AddRange(
                     new Camp
                     {
                         FullName = "John Buckley",
                         DateRegistered = DateTime.Parse("2017-2-8"),
                         BeltGrade = "Green",
                         ClubLocation = "Tralee",
                         DepositPutDown = 125
                     },

                    new Camp
                     {
                         FullName = "John Bishop",
                         DateRegistered = DateTime.Parse("2017-3-8"),
                         BeltGrade = "Blue",
                         ClubLocation = "Tralee",
                         DepositPutDown = 120
                     },

                    new Camp
                    {
                        FullName = "Rachel Buckley",
                        DateRegistered = DateTime.Parse("2017-1-9"),
                        BeltGrade = "Blue",
                        ClubLocation = "Tralee",
                        DepositPutDown = 110
                    },


                    new Camp
                   {
                       FullName = "Jordan Buckley",
                       DateRegistered = DateTime.Parse("2017-2-11"),
                       BeltGrade = "Green",
                       ClubLocation = "Tralee",
                       DepositPutDown = 120
                   }

                );
                context.SaveChanges();
            }
        }
    }
}