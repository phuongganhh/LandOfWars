using PA;
using PA.Extensions;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PA.Repository;

namespace PA.API.Models.CqCrystalGuiSetup
{
    public class CqCrystalGuiSetupDeleteByIdAction : CommandBase
    {
        public int? player_id { get; set; }
        protected override void ValidateCore(ObjectContext context)
        {
            if (this.player_id == null)
                throw new BusinessException("player_id không được null", System.Net.HttpStatusCode.BadRequest);
        }
        private Result DeleteData(ObjectContext context)
        {
            using(var cmd = new CqCrystalGuiSetupDeleteByIdRepository())
			{
				cmd.player_id = this.player_id;
				return cmd.Execute(context);
			}
        }
        protected override Result ExecuteCore(ObjectContext context)
        {
            return this.DeleteData(context);
        }
    }
}