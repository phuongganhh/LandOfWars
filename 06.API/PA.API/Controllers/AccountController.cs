using PA.API.Models.Account;
using PA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PA.API.Models;

namespace PA.API.Controllers
{
    public class AccountController : PAController
    {
        [HttpGet]
		[PAPermission(PermissionType.Guest)]
        public ActionResult Get(AccountGetAction ActionCmd)
        {
            return JsonExpando(ActionCmd.Execute(CurrentObjectContext));
        }
        [HttpGet]
		[PAPermission(PermissionType.Guest)]
        public ActionResult GetChart(AccountGetChartAction ActionCmd)
        {
            return JsonExpando(ActionCmd.Execute(CurrentObjectContext));
        }
        [HttpGet]
		[PAPermission(PermissionType.Admin)]
        public ActionResult Search(AccountSearchAction ActionCmd)
        {
            return JsonExpando(ActionCmd.Execute(CurrentObjectContext));
        }
        [HttpPost]
		[PAPermission(PermissionType.Admin)]
        public ActionResult GetById(AccountGetByIdAction ActionCmd)
        {
            return JsonExpando(ActionCmd.Execute(CurrentObjectContext));
        }
        [HttpPost]
		[PAPermission(PermissionType.Admin)]
        public ActionResult UpdateById(AccountUpdateByIdAction ActionCmd)
        {
            return JsonExpando(ActionCmd.Execute(CurrentObjectContext));
        }
        [HttpPost]
		[PAPermission(PermissionType.Admin)]
        public ActionResult DeleteById(AccountDeleteByIdAction ActionCmd)
        {
            return JsonExpando(ActionCmd.Execute(CurrentObjectContext));
        }
        [HttpPost]
		[PAPermission(PermissionType.Admin)]
        public ActionResult Insert(AccountInsertAction ActionCmd)
        {
            return JsonExpando(ActionCmd.Execute(CurrentObjectContext));
        }

    }
}