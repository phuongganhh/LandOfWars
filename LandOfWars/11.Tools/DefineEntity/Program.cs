using PA.Extensions;
using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefineEntity
{
    internal class tableName
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
                case "char": return "string";
                case "tinyint": return "int?";
                case "smallint": return "int?";
                case "bigint": return "long?";
                case "date": return "DateTime?";
                case "timestamp": return "DateTime?";
                default: return null;
            }
        }
    }
    class Program
    {

        private static QueryFactory db
        {
            get
            {
                var connection = new SqlConnection();
                var compiler = new MySqlCompiler();
                var db = new QueryFactory(connection, compiler);
                return db;
            }
        }
        private static List<string> listTable { get; set; }
        private static IDictionary<string, List<tableName>> dicCol { get; set; }
        private static List<string> GetTable()
        {
            if (listTable == null)
                listTable = db.From("information_schema.tables")
                .Reader<dynamic>()
                .Select(x => {
                    string s = x.TABLE_NAME;
                    return s;
                })
                .ToList();
            return listTable;
        }
        private static List<tableName> getColumnName(string tableName)
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
        private static string getFile()
        {
            using (var r = new StreamReader("Entity.txt"))
            {
                return r.ReadToEnd();
            }
        }
        private static StringBuilder getEntity(string tableName)
        {
            var col = getColumnName(tableName);
            var text = getFile();
            StringBuilder builder = new StringBuilder();
            col.ForEach(prop =>
            {
                var typeo = prop.getType();
                if(typeo == null)
                {
                    if (error == null) error = new Dictionary<string, string>();
                    error[prop.name] = prop.type;
                }
                else
                {
                    var txt = $"\t\tpublic {prop.getType()} {prop.name} " + "{ get; set; }";
                    Console.WriteLine(txt);
                    builder.AppendLine(txt);
                }
            });
            var t = text.Replace("{loop}", builder.ToString()).Replace("{tableName}", tableName);
            builder.Clear();
            builder.Append(t);
            return builder;
        }
        private static Dictionary<string,string> error { get; set; }
        static void WriteFile(string table,string text)
        {
            if (!Directory.Exists("Entity"))
            {
                Directory.CreateDirectory("Entity");
            }
            using(var w = new StreamWriter("Entity\\" +table + ".cs"))
            {
                w.Write(text);
            }
        }
        static void Main(string[] args)
        {
            try
            {
                
                MySqlExtension.connection_tring = @"server=localhost;user id=root;database=pa";
                GetTable().ForEach(item =>
                {
                    WriteFile(item, getEntity(item).ToString());
                });
                Process.Start(Directory.GetCurrentDirectory() + "\\Entity");
                throw new Exception("DONE!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if(error != null)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    error.ToList().ForEach(item =>
                    {
                        Console.WriteLine($"{item.Key} : {item.Value}");
                    });
                }
                Console.ReadLine();
            }
        }
    }
}
