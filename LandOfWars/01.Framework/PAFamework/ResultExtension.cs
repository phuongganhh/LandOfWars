using System;

namespace PA.Framework
{
    public static class ResultExtensions
    {
        public static IResult ThrowIfFail(this IResult obj, string keyword = "Message")
        {
            if (obj.is_success == false)
                throw new Exception(string.Format("{0} : {1}", keyword, obj.msg));
            return obj;
        }
        public static IResult<T> ThrowIfFail<T>(this IResult<T> obj, string keyword = "Message")
        {
            return ((IResult)obj).ThrowIfFail(keyword) as IResult<T>;
        }
    }
}
