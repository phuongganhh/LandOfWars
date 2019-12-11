using PA.Caching;
using Newtonsoft.Json;
using SqlKata;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using MySql.Data.MySqlClient;

namespace PA.Extensions
{
    public static class MySqlExtension
    {
        public static string connection_tring { get; set; }
        private static string dbc
        {
            get
            {
                if (connection_tring != null)
                    return connection_tring;
                return ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
            }
        }
        private static bool vnIsNull(this object thiz)
        {
            return thiz == null || thiz == DBNull.Value;
        }
        private static dynamic vnMappingToDynamic(this IDataReader reader)
        {
            dynamic item = new ExpandoObject();
            var dict = (IDictionary<string, object>)item;
            for (int i = 0; i < reader.FieldCount; i++)
            {
                var val = reader.GetValue(i);
                dict.Add(reader.GetName(i), val.vnIsNull() ? null : val);
            }
            return item;
        }
        private static void MapParameter(this MySqlParameterCollection param, Dictionary<string, Object> dic)
        {
            foreach (KeyValuePair<string, Object> entry in dic)
            {
                param.AddWithValue(entry.Key, dic[entry.Key] ?? DBNull.Value);
            }
        }
        private static string valid(this object s)
        {
            if (s == null)
            {
                return null;
            }
            return s.ToString().Replace("<script", "[removed").Replace("<link", "[removed");
        }
        private static string ConvertToSqlServer(this SqlResult query)
        {
            return query.Sql;
        }
        public static List<T> Reader<T>(this Query query) where T : class, new()
        {
            var items = new List<T>();
            using (var conn = new MySqlConnection(dbc))
            {
                DataTable data = new DataTable();
                try
                {
                    conn.Open();
                }
                catch (Exception)
                {
                    throw new Exception("Cannot connect to DB server");
                }
                using (var cmd = conn.CreateCommand())
                {
                    var sql = QueryHelper.CreateQueryFactory(query).Compiler.Compile(query);
                    cmd.CommandText = sql.ConvertToSqlServer();
                    cmd.Parameters.MapParameter(sql.NamedBindings);
                    using (var reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            if (typeof(List<T>) == typeof(List<dynamic>))
                            {
                                items.Add(reader.vnMappingToDynamic());
                            }
                            else
                            {
                                items.Add(reader.CreateRecord<T>());
                            }

                        }
                        reader.Close();
                        conn.Close();
                    }
                }
            }
            return items;
        }
        private static IEnumerable<PropertyInfo> GetPropertiesWithCache(this Type type, string key = null, int CacheTimeByMinute = 3)
        {
            if (key == null)
            {
                key = type.FullName;
            }
            return MemoryCacheManager.Instance.GetOrSet(key, () => type.GetProperties(), CacheTimeByMinute);
        }
        private static T CreateRecord<T>(this IDataRecord record, T myClass = null) where T : class, new()
        {
            var propertyInfos = typeof(T).GetPropertiesWithCache();

            if (myClass == null)
                myClass = new T();
            for (int i = 0; i < record.FieldCount; i++)
            {
                foreach (PropertyInfo propertyInfo in propertyInfos)
                {
                    if (propertyInfo.Name == record.GetName(i) && record.GetValue(i) != DBNull.Value)
                    {
                        propertyInfo.SetValue(myClass, Convert.ChangeType(record.GetValue(i), record.GetFieldType(i)), null);
                        break;
                    }

                }
            }
            return myClass;
        }
        private static List<string> GetPArameter(string sql)
        {
            var ar = sql.Split(' ');
            var l = new List<string>();
            foreach (var item in ar)
            {
                if (item.IndexOf('@') > -1)
                {
                    l.Add(item);
                }
            }
            return l;
        }
        public static int ExecuteNonReader(this SqlResult query)
        {
            using (var conn = new MySqlConnection(dbc))
            {
                try
                {
                    conn.Open();
                }
                catch (Exception)
                {
                    throw new Exception("Cannot connect to DB server");
                }
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = query.ConvertToSqlServer();
                    cmd.Parameters.MapParameter(query.NamedBindings);
                    var reader = cmd.ExecuteNonQuery();
                    conn.Close();
                    return Convert.ToInt32(reader);
                }

            }
        }

    }
}
