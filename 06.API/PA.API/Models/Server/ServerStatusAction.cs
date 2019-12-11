using Entities;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Web;

namespace PA.API.Models.Server
{
    public class ServerStatusAction : CommandBase<dynamic>
    {
        private bool Online(ObjectContext context)
        {
            using (TcpClient tcpClient = new TcpClient())
            {
                try
                {
                    var result = tcpClient.BeginConnect("103.27.237.153", 5816, null, null);
                    var success = result.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(DateTime.Now.Second + 5));
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        private IEnumerable<dynamic> GetUserOnline(ObjectContext context)
        {
            return context.db.From("cq_user")
                .Result<cq_user>()
                .Where(x => x.login_time > x.last_logout2)
                .Select(x =>
                {
                    return x.name;
                });
                ;
        }
        private dynamic GetNoti(ObjectContext context)
        {
            return context.db.From("ad_queue").Result<dynamic>().FirstOrDefault();
        }
        protected override Result<dynamic> ExecuteCore(ObjectContext context)
        {
            return Success(new
            {
                is_online = this.Online(context),
                user_online = this.GetUserOnline(context),
                time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                message = this.GetNoti(context)
            });
        }
    }
}