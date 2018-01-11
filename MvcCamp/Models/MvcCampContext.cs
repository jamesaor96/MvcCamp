using Microsoft.EntityFrameworkCore;



//Code below is based on "Create a web app with ASP.NET Core MVC using Visual Studio for Mac", www.microsoft.com, https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app-mac/
namespace MvcCamp.Models
{
    public class MvcCampContext : DbContext
    {
        public MvcCampContext(DbContextOptions<MvcCampContext> options)
            : base(options)
        {
        }

        public DbSet<MvcCamp.Models.Camp> Camp { get; set; }
    }
}