using PA.API.Models.CqStarmissionPrizeRule;
using PA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PA.API.Controllers
{
    public class CqStarmissionPrizeRuleController : PAController
    {
        [HttpGet]
		[PAPermission(PermissionType.Admin)]
        public ActionResult Search(CqStarmissionPrizeRuleSearchAction ActionCmd)
        {
            return JsonExpando(ActionCmd.Execute(CurrentObjectContext));
        }
        [HttpGet]
		[PAPermission(PermissionType.Admin)]
        public ActionResult GetById(CqStarmissionPrizeRuleGetByIdAction ActionCmd)
        {
            return JsonExpando(ActionCmd.Execute(CurrentObjectContext));
        }
        [HttpGet]
		[PAPermission(PermissionType.Admin)]
        public ActionResult UpdateById(CqStarmissionPrizeRuleUpdateByIdAction ActionCmd)
        {
            return JsonExpando(ActionCmd.Execute(CurrentObjectContext));
        }
        [HttpGet]
		[PAPermission(PermissionType.Admin)]
        public ActionResult DeleteById(CqStarmissionPrizeRuleDeleteByIdAction ActionCmd)
        {
            return JsonExpando(ActionCmd.Execute(CurrentObjectContext));
        }
        [HttpGet]
		[PAPermission(PermissionType.Admin)]
        public ActionResult Insert(CqStarmissionPrizeRuleInsertAction ActionCmd)
        {
            return JsonExpando(ActionCmd.Execute(CurrentObjectContext));
        }

    }
}