using PA.API.Models.CqSysShopPrice;
using PA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PA.API.Controllers
{
    public class CqSysShopPriceController : PAController
    {
        [HttpGet]
		[PAPermission(PermissionType.Admin)]
        public ActionResult Search(CqSysShopPriceSearchAction ActionCmd)
        {
            return JsonExpando(ActionCmd.Execute(CurrentObjectContext));
        }
        [HttpGet]
		[PAPermission(PermissionType.Admin)]
        public ActionResult GetById(CqSysShopPriceGetByIdAction ActionCmd)
        {
            return JsonExpando(ActionCmd.Execute(CurrentObjectContext));
        }
        [HttpGet]
		[PAPermission(PermissionType.Admin)]
        public ActionResult UpdateById(CqSysShopPriceUpdateByIdAction ActionCmd)
        {
            return JsonExpando(ActionCmd.Execute(CurrentObjectContext));
        }
        [HttpGet]
		[PAPermission(PermissionType.Admin)]
        public ActionResult DeleteById(CqSysShopPriceDeleteByIdAction ActionCmd)
        {
            return JsonExpando(ActionCmd.Execute(CurrentObjectContext));
        }
        [HttpGet]
		[PAPermission(PermissionType.Admin)]
        public ActionResult Insert(CqSysShopPriceInsertAction ActionCmd)
        {
            return JsonExpando(ActionCmd.Execute(CurrentObjectContext));
        }

    }
}