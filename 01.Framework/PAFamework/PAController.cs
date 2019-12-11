using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Entities;
using Newtonsoft.Json;

namespace PA
{
    public class PAController : Controller
    {
        public ObjectContext CurrentObjectContext { get; internal set; }
        public string CommonPage
        {
            get
            {
                return "~/Views/Layout/CommonLayout.cshtml";
            }
        }
        public string EmptyPage
        {
            get
            {
                return "~/Views/Layout/EmptyLayout.cshtml";
            }
        }
        protected override void OnActionExecuting(ActionExecutingContext ctx)
        {
            this.CreateObjectContext();
            base.OnActionExecuting(ctx);
        }
        protected virtual void CreateObjectContext()
        {
            CurrentObjectContext = ObjectContext.CreateContext(this);
        }

        protected ActionResult JsonExpando(object obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            return Content(json, "application/json");
        }
    }
}
