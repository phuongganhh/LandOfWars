using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA
{
    public static class PermissionType
    {
        public const int Admin = -1;
        public const int Guest = 0;

        public static string GetName(int i)
        {
            switch (i)
            {
                case Admin: return "Admin";
                case Guest: return "Guest";
                default:
                    return "Khách";
            }
        }
    }
}
