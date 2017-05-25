﻿using System.Web.Mvc;

namespace MyProject.Presentation.MVC.Areas.Administration
{
    public class AdministrationAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Administration";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
          context.MapRoute(
                "Administration_default",
                "Administration/{controller}/{action}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}