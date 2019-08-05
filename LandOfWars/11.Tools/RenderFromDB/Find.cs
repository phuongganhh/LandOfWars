using MySql.Data.MySqlClient;
using PA;
using PA.Extensions;
using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenderFromDB
{
    public class Find : CommandBase
    {
        private QueryFactory db
        {
            get
            {
                var connection = new MySqlConnection();
                var compiler = new MySqlCompiler();
                var db = new QueryFactory(connection, compiler);
                return db;
            }
        }
        private List<Database> databases { get; set; }

        protected override Result ExecuteCore(ObjectContext context)
        {
            this.GetDatabase();
            return Success();
        }
        private void GetDatabase()
        {
            
        }
    }
}
