using System.Web.Mvc;

namespace VideoClub.Web.Areas.Rentals
{
    public class RentalsAreaRegistration : AreaRegistration 
    {
        public override string AreaName => "Rentals";

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Rentals_default",
                "Rentals/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}