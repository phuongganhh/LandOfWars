using PA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA.Common
{
    public static class Extensions
    {
        public static string Currency(this package p)
        {
            if (p.type.Value == PackageType.Normal) return "VNĐ";
            if (p.type.Value == PackageType.Zp_free) return "ZPFree";
            return "đ";
        }
        public static DateTime GetTime(this long? times)
        {
            try
            {
                var time = Convert.ToInt32(times);
                var mm = time % 100;
                time /= 100;
                var HH = time % 100;
                time /= 100;
                var dd = time % 100;
                time /= 100;
                var MM = time % 100;
                time /= 100;
                var yy = time % 100 + 2000;
                time /= 100;
                return new DateTime(yy, MM, dd, HH, mm, 0);
            }
            catch (Exception ex)
            {
                return DateTime.Now;
            }
            
        }
    }
}
