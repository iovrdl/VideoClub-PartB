using System.Web.Mvc;

namespace VideoClub.Web.Areas.Films
{
    public class FilmsAreaRegistration : AreaRegistration
    {
        public override string AreaName => "Films";

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Films_default",
                "Films/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}