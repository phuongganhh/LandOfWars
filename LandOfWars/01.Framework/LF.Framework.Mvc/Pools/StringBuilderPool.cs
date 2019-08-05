using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LF.Framework
{
    public class StringBuilderPool
    {
        private static Pool<StringBuilder> pool = new Pool<StringBuilder>(10, p => new StringBuilder(1024));
        private static Pool<StringBuilder> poolLarge = new Pool<StringBuilder>(10, p => new StringBuilder(1024*1024));

        public static void Process(Action<StringBuilder> action, bool isLarge = false)
        {
            var p = isLarge == true ?  poolLarge : pool;
            var sb = p.Acquire();
            action(sb);
            sb.Clear();
            p.Release(sb);
        }

        public static void Process(Action<StringBuilder, StringBuilder> action, bool isLarge = false)
        {
            var p1 = isLarge == true ? poolLarge : pool;
            var sb1 = p1.Acquire();
            var p2 = isLarge == true ? poolLarge : pool;
            var sb2 = p2.Acquire();
            action(sb1, sb2);
            sb1.Clear();
            p1.Release(sb1);
            sb2.Clear();
            p2.Release(sb2);
        }

        public static string ProcessWithResult(Action<StringBuilder> action, bool isLarge = false)
        {
            string result = string.Empty;
            Process(sb=>
            {
                action(sb);
                result = sb.ToString();
            });
            return result;
        }
    }
}
