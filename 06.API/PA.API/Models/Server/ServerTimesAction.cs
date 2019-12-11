using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.API.Models.Server
{
    public class ServerTimesAction : CommandBase<dynamic>
    {
        protected override Result<dynamic> ExecuteCore(ObjectContext context)
        {
            return Success(new
            {
                time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            });
        }
    }
}