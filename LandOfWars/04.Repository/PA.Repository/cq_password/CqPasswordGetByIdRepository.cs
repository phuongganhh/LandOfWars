using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqPasswordGetByIdRepository<T> : CommandBase<T> where T : class,new()
    {
        public int? ID { get; set; }
        protected override void ValidateCore(ObjectContext context)
        {
           if(this.ID == null)
            {
                throw new BusinessException("ID is not nullable", System.Net.HttpStatusCode.BadRequest);
            }
        }
        private T GetData(ObjectContext context)
        {
            return context.db
                .From("cq_password")
                .Where("cq_password.ID",this.ID)
				.Select(
					"cq_password.ID",
					"cq_password.A",
					"cq_password.B",
					"cq_password.C",
					"cq_password.D",
					"cq_password.E",
					"cq_password.F",
					"cq_password.G",
					"cq_password.H",
					"cq_password.I",
					"cq_password.J",
					"cq_password.K",
					"cq_password.L",
					"cq_password.M",
					"cq_password.N",
					"cq_password.O",
					"cq_password.P",
					"cq_password.Q",
					"cq_password.R",
					"cq_password.S",
					"cq_password.T",
					"cq_password.U",
					"cq_password.V",
					"cq_password.W",
					"cq_password.X",
					"cq_password.Y",
					"cq_password.Z"
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