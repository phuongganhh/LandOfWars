using Entities;
using Newtonsoft.Json;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Web.Mvc;

namespace PA
{
    public class PAAuthorizeAttr : ActionFilterAttribute
    {
        private static readonly Type allowAnonymousAttrType = typeof(PAAllowAnonymus);
        private Type permissionAttr = typeof(PAPermission);

        private account GetAccount(ObjectContext context,string id)
        {
            return context.db.From("jz_acc.account").Where("jz_acc.account.id",id).Result<account>().FirstOrDefault();
        }
        private cq_user GetUser(ObjectContext context, string id)
        {
            return context.db.From("jz.cq_user").Where("jz.cq_user.account_id", id).Result<cq_user>().FirstOrDefault();
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                if (filterContext.ActionDescriptor.IsDefined(allowAnonymousAttrType, true) ||
                filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(allowAnonymousAttrType, true))
                {
                    return;
                }
                var controller = filterContext.Controller as PAController;
                var headers = filterContext.RequestContext.HttpContext.Request.Params.AllKeys.ToList();
                var jtoken = headers.FirstOrDefault(x => x == "access-token");
                if (jtoken == null)
                {
                    filterContext.Result = new JsonResult()
                    {
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                        Data = new Result
                        {
                            is_success = true,
                            error_code = (int)HttpStatusCode.Unauthorized,
                            msg = "Vui lòng đăng nhập!"
                        }
                    };
                    return;
                }
                var userId = controller.CurrentObjectContext.ValidJWT(filterContext.RequestContext.HttpContext.Request.Params[jtoken]);
                if(userId == null)
                {
                    filterContext.Result = new JsonResult()
                    {
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                        Data = new Result
                        {
                            error_code = (int)HttpStatusCode.Unauthorized,
                            msg = "Phiên làm việc hết hạn, vui lòng đăng nhập lại!",
                            is_success = true
                        }
                    };
                    return;
                }
                else
                {
                    // set get user
                    controller.CurrentObjectContext.setUser(userId);
                }
                void UnAuthorize()
                {
                    filterContext.Result = new JsonResult()
                    {
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                        Data = new Result
                        {
                            error_code = (int)HttpStatusCode.Forbidden,
                            msg = "Bạn không có quyền truy cập!",
                            is_success = true
                        }
                    };
                    return;
                }
                var permissionController = (filterContext.ActionDescriptor.GetCustomAttributes(this.permissionAttr, false).FirstOrDefault() as PAPermission)?.permission_id ?? PermissionType.Guest;
                var _acc = this.GetAccount(controller.CurrentObjectContext, userId);
                var PAUser = _acc?.permission_id ?? PermissionType.Guest;
                if(PAUser == PermissionType.Admin || permissionController == PermissionType.Guest || PAUser == permissionController)
                {
                    //Có đủ quyền truy cập
                    controller.CurrentObjectContext.GetAccount = _acc;
                    controller.CurrentObjectContext.GetUser = this.GetUser(controller.CurrentObjectContext, userId);
                    return;
                }
                else
                {
                    // không có quyền truy cập
                    UnAuthorize();
                    return;
                }


            }
            catch (Exception ex)
            {
                filterContext.Result = new JsonResult()
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new Result
                    {
                        is_success = false,
                        error_code = (int)HttpStatusCode.InternalServerError,
                        msg = ex.Message
                    }
                };
            }
            
            base.OnActionExecuting(filterContext);
        }
    }
}
