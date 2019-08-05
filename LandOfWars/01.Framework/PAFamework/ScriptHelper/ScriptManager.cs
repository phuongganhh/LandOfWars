using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Web.Mvc;

namespace PA.Framework
{
    public class ScriptManager
    {
        public List<string> scripts = new List<string>();
        public List<string> scriptFiles = new List<string>();
    }
    public static class HtmlExtensions
    {
        [ThreadStatic]
        private static ControllerBase PAgeDataController;
        [ThreadStatic]
        private static ScriptManager PAgeData;

        public static ScriptManager ScriptManager(this HtmlHelper html)
        {
            ControllerBase controller = html.ViewContext.Controller;

            // This makes sure we get the top-most controller
            while (controller.ControllerContext.IsChildAction)
            {
                controller = controller.ControllerContext.ParentActionViewContext.Controller;
            }
            if (PAgeDataController == controller)
            {
                // We've been here before
                return PAgeData;
            }
            else
            {
                // Initial setup
                PAgeDataController = controller;
                PAgeData = new ScriptManager();
                return PAgeData;
            }
        }
    }
}
