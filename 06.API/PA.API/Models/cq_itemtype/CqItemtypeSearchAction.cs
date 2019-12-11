using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PA.Repository; using System.Net;
namespace PA.API.Models.CqItemtype
{
    public class CqItemtypeSearchAction : CommandBase<Paging<dynamic>>
    {
		public CqItemtypeSearchRepository<dynamic> CommandAction { get; set; }
		protected override void OnExecutingCore(ObjectContext context)
		{
			if(this.CommandAction == null)
				this.CommandAction = new CqItemtypeSearchRepository<dynamic>();
		}
        protected override Result<Paging<dynamic>> ExecuteCore(ObjectContext context)
        {
            return this.CommandAction.Execute(context);
        }
    }
}