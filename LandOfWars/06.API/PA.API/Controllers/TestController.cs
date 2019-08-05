using Newtonsoft.Json;
using PA.Extensions;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PA.API.Controllers
{
    public class TestController : PAController
    {
        // GET: Test
        [PAPermission(PermissionType.Guest)]
        public ActionResult subAPI()
        {
            var data = CurrentObjectContext.sql.From("package");
            var sql = QueryHelper.CreateQueryFactory(data).Compiler.Compile(data);
            return JsonExpando(new {
                world = "hello"
            });
        }
    }
}