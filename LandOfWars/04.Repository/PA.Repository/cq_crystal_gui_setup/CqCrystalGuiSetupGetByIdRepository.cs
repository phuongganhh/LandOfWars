using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqCrystalGuiSetupGetByIdRepository<T> : CommandBase<T> where T : class,new()
    {
        public int? player_id { get; set; }
        protected override void ValidateCore(ObjectContext context)
        {
           if(this.player_id == null)
            {
                throw new BusinessException("player_id is not nullable", System.Net.HttpStatusCode.BadRequest);
            }
        }
        private T GetData(ObjectContext context)
        {
            return context.db
                .From("cq_crystal_gui_setup")
                .Where("cq_crystal_gui_setup.player_id",this.player_id)
				.Select(
					"cq_crystal_gui_setup.player_id",
					"cq_crystal_gui_setup.gui0",
					"cq_crystal_gui_setup.gui1",
					"cq_crystal_gui_setup.gui2",
					"cq_crystal_gui_setup.gui3",
					"cq_crystal_gui_setup.gui4",
					"cq_crystal_gui_setup.gui5"
				)
                .Result<T>()
                .FirstOrDefault()
                ;
        }
        protected override Result<T> ExecuteCore(ObjectContext context)
        {
            return Success(this.GetData(context));
        }
    }
}