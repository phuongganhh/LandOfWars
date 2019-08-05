using MySql.Data.MySqlClient;
using PA.Extensions;
using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenerateEntity
{
    public class tableName
    {
        public string name { get; set; }
        public string type { get; set; }
        public string is_nullable { get; set; }
        public string nullable { get; set; }

        public string getType()
        {
            switch (this.type)
            {
                case "int": return "int?";
                case "varchar": return "string";
                case "char": return "char";
                case "tinyint": return "int?";
                case "smallint": return "int?";
                case "bigint": return "long?";
                default: return "unknown";
            }
        }
    }
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
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
        private static List<string> listTable { get; set; }
        private static IDictionary<string,List<tableName>> dicCol { get; set; }
        private List<string> GetTable()
        {
            if(listTable == null)
                listTable = db.From("information_schema.tables")
                .WhereLike("table_name","cq%")
                .Reader<dynamic>()
                .Select(x => {
                    string s = x.TABLE_NAME;
                    return s;
                })
                .ToList();
            return listTable;
        }
        private List<tableName> getColumnName(string tableName)
        {
            if (dicCol == null)
                dicCol = new Dictionary<string, List<tableName>>();
            if (!dicCol.ContainsKey(tableName))
            {
                dicCol[tableName] = db.From("information_schema.columns")
                                       .Select(
                                            "COLUMN_NAME as name",
                                            "IS_NULLABLE as is_nullable",
                                            "DATA_TYPE as type"
                                       )
                                       .Where("table_schema", "jz")
                                       .Where("table_name", tableName)
                                       .Reader<tableName>()
                                       .Select(x =>
                                       {
                                           x.nullable = x.is_nullable != "NO" ? "?" : "";
                                           return x;
                                       })
                                       .ToList()
                                       ;
            }
            return dicCol[tableName];
        }
        private string getFile()
        {
            using (var r = new StreamReader("Entity.txt"))
            {
                return r.ReadToEnd();
            }
        }
        private StringBuilder getEntity(string tableName)
        {
            var col = this.getColumnName(tableName);
            var text = this.getFile();
            StringBuilder builder = new StringBuilder();
            col.ForEach(prop =>
            {
                builder.AppendLine($"public {prop.getType()} {prop.name} " + "{ get; set; }");
            });
            return builder;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            MySqlExtension.connection_tring = @"server=localhost;user id=root;database=jz";
            this.GetTable().ForEach(item=>
            {
                var col = this.getEntity(item);
            });
        }
    }
}
