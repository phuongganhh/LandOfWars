using PA.API.Models.Robot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PA.API.Controllers
{
    public class RobotController : PAController
    {
        // GET: Robot
        public ActionResult Get(RobotGetAction ActionCmd)
        {
            return JsonExpando(ActionCmd.Execute(CurrentObjectContext));
        }
        public ActionResult Exp(RobotExpAction ActionCmd)
        {
            return JsonExpando(ActionCmd.Execute(CurrentObjectContext));
        }
        public ActionResult Ranks(RobotRanksAction ActionCmd)
        {
            return JsonExpando(ActionCmd.Execute(CurrentObjectContext));
        }
    }
}