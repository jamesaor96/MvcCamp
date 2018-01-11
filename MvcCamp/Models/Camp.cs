using System;
using System.ComponentModel.DataAnnotations;


//Code below is based on "Create a web app with ASP.NET Core MVC using Visual Studio for Mac", www.microsoft.com, https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app-mac/
namespace MvcCamp.Models
{
    public class Camp
    {
        public int ID { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Display(Name = "Date Registered")]
        [DataType(DataType.Date)]
        public DateTime DateRegistered { get; set; }

        [Display(Name = "Belt Grade")]
        public string BeltGrade { get; set; }

        [Display(Name = "Club Location")]
        public string ClubLocation { get; set; }

        [Display(Name = "Deposit Placed")]
        public decimal DepositPutDown { get; set; }
    }
}