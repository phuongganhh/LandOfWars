using PA.API.Models.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PA.API.Controllers
{
    public class SystemController : PAController
    {
        // GET: System
        [PAPermission(PermissionType.Admin)]
        public ActionResult Status(SystemStatusAction ActionCmd)
        {
            return JsonExpando(ActionCmd.Execute(CurrentObjectContext));
        }
    }
}