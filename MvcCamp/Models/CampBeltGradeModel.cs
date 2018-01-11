//Code below is based on "Create a web app with ASP.NET Core MVC using Visual Studio for Mac", www.microsoft.com, https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app-mac/
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MvcCamp.Models
{
    public class CampBeltGradeModel
    {
        public List<Camp> camps;
        public SelectList beltGrades;
        public string campBeltGrade { get; set; }
    }
}