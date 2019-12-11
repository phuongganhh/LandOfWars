using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA.Framework
{
    /// <summary>
    /// 1. Create Date: 2017.11.08
    /// 2. Creator: tran phuoc tuan
    /// 3. Description: implement Generic Singleton Pattern
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Singleton<T> //where T : class, new()
    {
        Singleton() { }

        //private static readonly Lazy<T> instance = new Lazy<T>(() => new T());
        private static readonly Lazy<T> instance = new Lazy<T>(() => (T)typeof(T).CreateInstance());
        public static T Instance
        {
            get
            {
                return instance.Value;
            }
        }
    }

    public class SingletonBase<T>
    {
        public static T Instance
        {
            get { return Singleton<T>.Instance; }
        }
    }
}
