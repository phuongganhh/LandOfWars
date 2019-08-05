using PA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.PA.Areas.Api.Models.Authorize;

namespace UI.PA.Areas.Api.Controllers
{
    public class AuthorizeController : PAController
    {
        [PAAllowAnonymus]
        public ActionResult SignIn(SignInAction ActionCmd)
        {
            return JsonExpando(ActionCmd.Execute(CurrentObjectContext));
        }
        [PAAllowAnonymus]
        public ActionResult SignUp(SignUpAction ActionCmd)
        {
            ActionCmd.MailContent = Server.MapPath("/Content/lib/MailContent.html");
            return JsonExpando(ActionCmd.Execute(CurrentObjectContext));
        }
    }
}