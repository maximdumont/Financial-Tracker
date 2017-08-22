using System;

namespace Service.Global.Extensions
{
    public static class ObjectExtensions
    {
        public static bool IsTrue<T>(this Func<T, bool> func, T arg)
        {
            return func.Invoke(arg);
        }

        public static bool IsNull(this object o)
        {
            return o == null;
        }
    }
}