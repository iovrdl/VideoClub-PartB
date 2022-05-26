﻿using System.Web.Mvc;

namespace VideoClub.Web.Areas.Customers
{
    public class CustomersAreaRegistration : AreaRegistration
    {
        public override string AreaName => "Customers";

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Customers_default",
                "Customers/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}