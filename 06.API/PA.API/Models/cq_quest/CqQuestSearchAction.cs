using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PA.Repository;
namespace PA.API.Models.CqQuest
{
    public class CqQuestSearchAction : CommandBase<Paging<dynamic>>
    {
		public CqQuestSearchRepository<dynamic> CommandAction { get; set; }
		protected override void OnExecutingCore(ObjectContext context)
		{
			if(this.CommandAction == null)
				this.CommandAction = new CqQuestSearchRepository<dynamic>();
		}
        protected override Result<Paging<dynamic>> ExecuteCore(ObjectContext context)
        {
            return this.CommandAction.Execute(context);
        }
    }
}