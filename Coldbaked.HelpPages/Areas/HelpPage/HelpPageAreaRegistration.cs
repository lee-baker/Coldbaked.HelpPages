using System.Web.Http;
using System.Web.Mvc;
using MvcContrib.PortableAreas;

namespace Coldbaked.HelpPages.Areas.HelpPage
{
    public class HelpPageAreaRegistration : PortableAreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "HelpPage";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context, IApplicationBus bus)
        {
            RegisterRoutes(context);
            HelpPageConfig.Register(GlobalConfiguration.Configuration);
            RegisterAreaEmbeddedResources();
        }

        private void RegisterRoutes(AreaRegistrationContext context)
        {
            RegisterDefaultRoutes(context);

            context.MapRoute(
                AreaName + "_default",
                "api/Help/{action}/{apiId}",
                new { controller = "Help", action = "Index", apiId = UrlParameter.Optional },
                new[] { "Coldbaked.HelpPages.Areas.HelpPage.Controllers", "MvcContrib" }
            );
        }
    }
}