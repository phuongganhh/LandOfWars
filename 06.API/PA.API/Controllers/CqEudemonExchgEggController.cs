using PA.API.Models.CqEudemonExchgEgg;
using PA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PA.API.Controllers
{
    public class CqEudemonExchgEggController : PAController
    {
        [HttpGet]
		[PAPermission(PermissionType.Admin)]
        public ActionResult Search(CqEudemonExchgEggSearchAction ActionCmd)
        {
            return JsonExpando(ActionCmd.Execute(CurrentObjectContext));
        }
        [HttpGet]
		[PAPermission(PermissionType.Admin)]
        public ActionResult GetById(CqEudemonExchgEggGetByIdAction ActionCmd)
        {
            return JsonExpando(ActionCmd.Execute(CurrentObjectContext));
        }
        [HttpGet]
		[PAPermission(PermissionType.Admin)]
        public ActionResult UpdateById(CqEudemonExchgEggUpdateByIdAction ActionCmd)
        {
            return JsonExpando(ActionCmd.Execute(CurrentObjectContext));
        }
        [HttpGet]
		[PAPermission(PermissionType.Admin)]
        public ActionResult DeleteById(CqEudemonExchgEggDeleteByIdAction ActionCmd)
        {
            return JsonExpando(ActionCmd.Execute(CurrentObjectContext));
        }
        [HttpGet]
		[PAPermission(PermissionType.Admin)]
        public ActionResult Insert(CqEudemonExchgEggInsertAction ActionCmd)
        {
            return JsonExpando(ActionCmd.Execute(CurrentObjectContext));
        }

    }
}