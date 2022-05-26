using System.Web.Mvc;

namespace VideoClub.Web.Areas.Home
{
    public class HomeAreaRegistration : AreaRegistration
    {
        public override string AreaName => "Home";

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Home_default",
                "Home/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}