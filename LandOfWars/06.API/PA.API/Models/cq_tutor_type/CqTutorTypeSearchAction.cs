using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PA.Repository;
namespace PA.API.Models.CqTutorType
{
    public class CqTutorTypeSearchAction : CommandBase<Paging<dynamic>>
    {
		public CqTutorTypeSearchRepository<dynamic> CommandAction { get; set; }
		protected override void OnExecutingCore(ObjectContext context)
		{
			if(this.CommandAction == null)
				this.CommandAction = new CqTutorTypeSearchRepository<dynamic>();
		}
        protected override Result<Paging<dynamic>> ExecuteCore(ObjectContext context)
        {
            return this.CommandAction.Execute(context);
        }
    }
}