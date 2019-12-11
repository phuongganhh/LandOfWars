using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA.Common.Card
{
    public static class CardPrice
    {
        public static readonly long _10 = 0;
        public static readonly long _20 = 1;
        public static readonly long _30 = 2;
        public static readonly long _50 = 3;
        public static readonly long _100 = 4;
        public static readonly long _200 = 5;
        public static readonly long _300 = 6;
        public static readonly long _500 = 7;
        public static long GetPrice(long id)
        {
            if (id == _10) return 10000;
            if (id == _20) return 20000;
            if (id == _30) return 30000;
            if (id == _50) return 50000;
            if (id == _100) return 100000;
            if (id == _200) return 200000;
            if (id == _300) return 300000;
            if (id == _500) return 500000;
            return 0;
        }
    }
}
