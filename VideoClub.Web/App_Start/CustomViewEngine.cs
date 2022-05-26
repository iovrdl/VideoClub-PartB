using System.Web.Mvc;

namespace VideoClub.Web
{
    public class CustomViewEngine : RazorViewEngine
    {
        public CustomViewEngine()
        {
            var viewLocations = new[]
            {
                "~/Views/{0}.cshtml",
                "~/Views/Shared/{0}.cshtml",
                "~/Areas/Home/Views/Home/{0}.cshtml",
                "~/Areas/Account/Views/Account/{0}.cshtml",
                "~/Areas/Manage/Views/Manage/{0}.cshtml",
                "~/Areas/Customers/Views/Customers/{0}.cshtml",
                "~/Areas/Films/Views/Films/{0}.cshtml",
                "~/Areas/Copies/Views/Copies/{0}.cshtml",
                "~/Areas/Rentals/Views/Rentals/{0}.cshtml"
            };

            PartialViewLocationFormats = viewLocations;
            ViewLocationFormats = viewLocations;
        }
    }
}