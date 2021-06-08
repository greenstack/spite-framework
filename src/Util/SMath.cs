using System;

namespace Spite.Util
{
    /// <summary>
    /// Provides some common math methods.
    /// </summary>
    public static class SMath
    {
        /// <summary>
        /// Provides a generic way to clamp values.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Clamp<T>(T value, T min, T max) where T :
            IComparable<T>,
            IEquatable<T>
        {
            if (value.CompareTo(min) < 0) return min;
            else if (value.CompareTo(max) > 0) return max;
            else return value;
        }
    }
}