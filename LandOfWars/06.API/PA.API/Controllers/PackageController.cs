using PA.API.Models;
using PA.API.Models.Package;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PA.API.Controllers
{
    public class PackageController : PAController
    {
        // GET: Package
        public ActionResult Search(PackageSearchAction ActionCmd)
        {
            return JsonExpando(ActionCmd.Execute(CurrentObjectContext));
        }
        public ActionResult Buy(PackageBuyAction ActionCmd)
        {
            return JsonExpando(ActionCmd.Execute(CurrentObjectContext));
        }
    }
}