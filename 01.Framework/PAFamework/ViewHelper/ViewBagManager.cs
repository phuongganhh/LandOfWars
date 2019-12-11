using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PA.Framework.Extensions
{
    public static class ViewBagManager
    {
        #region Scripts Manager

        public static string ScriptManagerName = Guid.NewGuid().ToString();
        public static List<string> getScripts(ObjectContext context)
        {
            return context.ViewData[ScriptManagerName] as List<string>;
        }
        public static void addScript(ObjectContext context, string scriptUrl)
        {
            if (context.ViewData[ScriptManagerName] == null)
            {
                context.ViewData[ScriptManagerName] = new List<string>();
            }
            var dict = context.ViewData[ScriptManagerName] as List<string>;

            dict.Add(scriptUrl);
        }
        #endregion

        #region CSS Manager

        public static string CSSManagerName = Guid.NewGuid().ToString();
        public static List<string> getCSSs(ObjectContext context)
        {
            return context.ViewData[CSSManagerName] as List<string>;
        }
        public static void addCSS(ObjectContext context, string scriptUrl)
        {
            if (context.ViewData[CSSManagerName] == null)
            {
                context.ViewData[CSSManagerName] = new List<string>();
            }
            var dict = context.ViewData[CSSManagerName] as List<string>;

            dict.Add(scriptUrl);
        }
        #endregion

        #region Javascript View Name Manager
        public static string JavascriptViewNameManager = Guid.NewGuid().ToString();

        public static void setJavascriptViewName(ObjectContext context, string ViewName)
        {
            context.ViewData[JavascriptViewNameManager] = ViewName;
        }

        public static string getJavascriptViewName(ObjectContext context)
        {
            if (context.ViewData[JavascriptViewNameManager] == null)
            {
                context.ViewData[JavascriptViewNameManager] = "";
            }
            return context.ViewData[JavascriptViewNameManager].ToString();
        }
        #endregion

        #region Javascript View PAth Manager
        public static string JavascriptViewPAthManager = Guid.NewGuid().ToString();

        public static void setJavascriptViewPAth(ObjectContext context, string ViewPAth)
        {
            context.ViewData[JavascriptViewPAthManager] = ViewPAth;
        }

        public static string getJavascriptViewPAth(ObjectContext context)
        {
            if (context.ViewData[JavascriptViewPAthManager] == null)
            {
                context.ViewData[JavascriptViewPAthManager] = "";
            }
            return context.ViewData[JavascriptViewPAthManager].ToString();
        }
        #endregion

        //ko reference chéo giữa 2 project infra.entity và framework.mvc được, nên em làm đỡ kiểu này
        public static void RedirectToUnAuthorize(this ObjectContext context, string message = null)
        {
            context.RedirectToNoticePAge(new MessageOption
            {
                Message = "Bạn không có quyền truy cập trang này",
                Title = "Thông báo quyền hạn"
            });
        }
        public static void RedirectToNoData(this ObjectContext context, string message = null, string title = null)
        {
            context.RedirectToNoticePAge(new MessageOption
            {
                Message = message ?? "Dữ liệu không tồn tại",
                Title = title ?? "Thông báo"
            });
        }
        public static void RedirectToNoticePAge(this ObjectContext context, MessageOption option)
        {
            context.ViewBag.mainData = option;
            ViewBagManager.setJavascriptViewPAth(context, "~/Views/CommonPAge/UnAuthorizePAge.js");
        }
        public static void RedirectToConfirmDeleteOne(this ObjectContext context, object Data = null)
        {
            context.ViewBag.DeleteData = Data;
            context.RedirectTo("~/Views/CommonPAge/ConfirmDeleteOne.js");
        }
        public static void RedirectToConfirmDeleteMulti(this ObjectContext context, List<long> DataId = null)
        {
            context.ViewBag.DeleteDataId = DataId;
            context.RedirectTo("~/Views/CommonPAge/ConfirmDeleteMulti.js");
        }
        public static void RedirectTo(this ObjectContext context, string ViewPAth)
        {
            ViewBagManager.setJavascriptViewPAth(context, ViewPAth);
        }

    }
    public class MessageOption
    {
        public string Message { get; set; }
        public string Title { get; set; }
    }
}
