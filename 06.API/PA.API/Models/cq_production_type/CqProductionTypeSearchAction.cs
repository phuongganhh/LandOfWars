using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PA.Repository;
namespace PA.API.Models.CqProductionType
{
    public class CqProductionTypeSearchAction : CommandBase<Paging<dynamic>>
    {
		public CqProductionTypeSearchRepository<dynamic> CommandAction { get; set; }
		protected override void OnExecutingCore(ObjectContext context)
		{
			if(this.CommandAction == null)
				this.CommandAction = new CqProductionTypeSearchRepository<dynamic>();
		}
        protected override Result<Paging<dynamic>> ExecuteCore(ObjectContext context)
        {
            return this.CommandAction.Execute(context);
        }
    }
}