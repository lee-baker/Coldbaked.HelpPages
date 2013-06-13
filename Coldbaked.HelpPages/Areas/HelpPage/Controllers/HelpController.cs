using System;
using System.Web.Http;
using System.Web.Mvc;
using Coldbaked.HelpPages.Models;
using System.Linq;

namespace Coldbaked.HelpPages.Areas.HelpPage.Controllers
{
    /// <summary>
    /// The controller that will handle requests for the help page.
    /// </summary>
    public class HelpController : Controller
    {
        public HelpController()
            : this(GlobalConfiguration.Configuration)
        {
        }

        public HelpController(HttpConfiguration config)
        {
            Configuration = config;
        }

        public HttpConfiguration Configuration { get; private set; }

        public ActionResult Index()
        {
            // Group APIs by controller and filter local only requests
            var descriptions = Configuration.Services.GetApiExplorer().ApiDescriptions.Where(
                    f => f.ActionDescriptor.GetCustomAttributes<InternalOnlyDocumentationAttribute>().Count == 0 || Request.IsLocal ).ToLookup(
                    api => api.ActionDescriptor.ControllerDescriptor.ControllerName);

            return View(descriptions);
        }

        public ActionResult Api(string apiId)
        {
            if (!String.IsNullOrEmpty(apiId))
            {
                HelpPageApiModel apiModel = Configuration.GetHelpPageApiModel(apiId);
                if (apiModel != null)
                {
                    return View(apiModel);
                }
            }

            return View("Error");
        }
    }
}