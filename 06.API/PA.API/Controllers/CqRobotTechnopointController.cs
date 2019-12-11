using PA.API.Models.CqRobotTechnopoint;
using PA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PA.API.Controllers
{
    public class CqRobotTechnopointController : PAController
    {
        [HttpGet]
		[PAPermission(PermissionType.Admin)]
        public ActionResult Search(CqRobotTechnopointSearchAction ActionCmd)
        {
            return JsonExpando(ActionCmd.Execute(CurrentObjectContext));
        }
        [HttpGet]
		[PAPermission(PermissionType.Admin)]
        public ActionResult GetById(CqRobotTechnopointGetByIdAction ActionCmd)
        {
            return JsonExpando(ActionCmd.Execute(CurrentObjectContext));
        }
        [HttpGet]
		[PAPermission(PermissionType.Admin)]
        public ActionResult UpdateById(CqRobotTechnopointUpdateByIdAction ActionCmd)
        {
            return JsonExpando(ActionCmd.Execute(CurrentObjectContext));
        }
        [HttpGet]
		[PAPermission(PermissionType.Admin)]
        public ActionResult DeleteById(CqRobotTechnopointDeleteByIdAction ActionCmd)
        {
            return JsonExpando(ActionCmd.Execute(CurrentObjectContext));
        }
        [HttpGet]
		[PAPermission(PermissionType.Admin)]
        public ActionResult Insert(CqRobotTechnopointInsertAction ActionCmd)
        {
            return JsonExpando(ActionCmd.Execute(CurrentObjectContext));
        }

    }
}