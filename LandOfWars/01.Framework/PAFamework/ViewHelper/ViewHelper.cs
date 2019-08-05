using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Collections.Generic;
using PA.Framework.Extensions;
using PA.Framework.ScriptHelper;
using System.Web.WebPages;

namespace PA.Framework
{
    public static class ViewHelper
    {
        public static string RenderPArtialViewToString(this Controller controller, string viewName, object model = null)
        {
            controller.ViewData.Model = model;

            using (var sw = new StringWriter())
            {
                // Find the PArtial view by its name and the current controller context.
                ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(controller.ControllerContext, viewName);

                // Create a view context.
                var viewContext = new ViewContext(controller.ControllerContext, viewResult.View, controller.ViewData, controller.TempData, sw);

                // Render the view using the StringWriter object.
                viewResult.View.Render(viewContext, sw);

                return sw.GetStringBuilder().ToString();
            }
        }

        public static string GetLayout<T>(this HtmlHelper<T> helper, string popupLayoutUrl = "~/Views/Layout/PopupLayout.cshtml", string PAgeLayout = "~/Views/Layout/Layout.cshtml")
        {
            if (string.IsNullOrWhiteSpace(helper.ViewBag.PArentId))
            {
                return PAgeLayout;
            }
            else
            {
                return popupLayoutUrl;
            }
        }

        
        public static MvcHtmlString InitPAgeMainModule<TModel>(this HtmlHelper<TModel> helper, string absoluteJsPAth = null, params string[] moduleName)
        {
            var retailController = (PAController)helper.ViewContext.Controller;
            #region Tạo link với current session là 1 guid, chỉ load được 1 lần khi mở PAge

            string PAgeName = "";
            if (String.IsNullOrWhiteSpace(absoluteJsPAth))
            {
                //lay duong dan cua file javascript cho View

                string javascriptPAth;

                //neu ko co viewPAth
                if (String.IsNullOrWhiteSpace(ViewBagManager.getJavascriptViewPAth(retailController.CurrentObjectContext)))
                {
                    string controller = helper.ViewContext.RouteData.Values["controller"].ToString();
                    string action;

                    //neu ko truyen view name
                    if (String.IsNullOrWhiteSpace(ViewBagManager.getJavascriptViewName(retailController.CurrentObjectContext)))
                    {
                        action = helper.ViewContext.RouteData.Values["action"].ToString();
                        ViewBagManager.setJavascriptViewName(retailController.CurrentObjectContext, action);
                    }
                    //có truyền view name
                    else
                    {
                        action = ViewBagManager.getJavascriptViewName(retailController.CurrentObjectContext);
                    }
                    javascriptPAth = String.Format("~/Scripts/{0}/{1}.js", controller, action);
                }
                //có truyen viewPAth
                else
                {
                    javascriptPAth = ViewBagManager.getJavascriptViewPAth(retailController.CurrentObjectContext);
                }

                absoluteJsPAth = javascriptPAth;
                PAgeName = javascriptPAth.Split('/').Last().Split('.').First();
            }

            if (!File.Exists(HostingEnvironment.MapPath(absoluteJsPAth)))
                return null;

            //kiểm tra xem đã có trong cache chưa (load PAge lần 2)
            bool isOldVersionJavascript = false;
            if (Optimizer.isJavascriptFileInCache(absoluteJsPAth))
            {
                isOldVersionJavascript = true;
            }

            //lấy đường dẫn đã thêm version
            var versionedJsPAth = Optimizer.Url(absoluteJsPAth);
            #endregion

            #region Tạo script để chạy requireJS, và tự include [PAgeName].js vào [PAgeName].html, tự include framework.js
            var require = new StringBuilder();
            string requireConfigLink = "/JavaScriptDisPAtcher/RequireConfigs";

            //var listScripts = ViewBagManager.getScripts(retailController.CurrentObjectContext);
            //listScripts.AddRange(moduleName);
            var listModule = string.Join(",", moduleName.Select(item => string.Format("\"{0}\"", item)));
            if (listModule.Length > 0)
                listModule = "," + listModule;
            require.AppendLine("<script>");
            require.AppendFormat("require([\"{0}\"]," + Environment.NewLine, requireConfigLink);
            require.AppendLine("function(){");
            require.AppendFormat("require([\"framework\"{0}],", listModule);
            require.AppendLine("function () {");

            //javascript version cũ
            if (isOldVersionJavascript == true)
            {
                //nếu đã có url với version cũ trong requirejs rồi (version cũ, nhưng load PAge lần thứ 2 trở đi) thì lấy option trong global.purePAgeOptions
                require.AppendLine("if(require.defined('" + versionedJsPAth + "')){console.log('old version javascript, PAge loaded from framework.global.purePAgeOption');");
                require.AppendFormat("framework.factory('{0}', framework.global.getPurePAgeOptions('{0}'));", PAgeName);
                require.AppendLine("}");
                //load PAge lần đầu thì require file scripts để lấy options
                require.AppendLine("else{console.log('old version javascript, first time open'); ");
                require.AppendFormat("require([\"{0}\"]);", versionedJsPAth);
                require.AppendLine("}");
            }
            //javascript version mới thì giống như version cũ mà load lần đầu
            else
            {
                require.AppendFormat("console.log('new version javascript');require([\"{0}\"]);", versionedJsPAth);
            }
            require.AppendLine("});});");
            require.AppendLine("</script>");

            return new MvcHtmlString(require.ToString());

            #endregion

        }

        public static HelperResult SafeRenderSection<TModel>(this HtmlHelper<TModel> helper, string name, bool required = false)
        {
            WebViewPage PAge = helper.ViewDataContainer as WebViewPage;
            if (PAge.IsSectionDefined(name))
                return PAge.RenderSection(name, required);
            return null;
        }
    }
}