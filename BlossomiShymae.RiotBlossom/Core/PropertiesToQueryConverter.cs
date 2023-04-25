using System.Reflection;
using System.Runtime.CompilerServices;

namespace BlossomiShymae.RiotBlossom.Core
{
    internal static class PropertiesToQueryConverter
    {
        static class Adapter<T>
        {
            private static readonly PropertyInfo[] s_properties = typeof(T).GetProperties();

            public static unsafe string ToQuery(T typeValue)
            {
                // Using stackalloc here causes CS8350 and CS8352 for handler.AppendFormatted below
                // Have to use unsafe modifier for compiler to accept this o.o
                Span<char> lowerCaseBuffer = stackalloc char[30];
                bool isFirstAppend = true;
                DefaultInterpolatedStringHandler handler = new();
                foreach (PropertyInfo propertyInfo in s_properties)
                {
                    var value = propertyInfo.GetValue(typeValue, null);
                    if (value == null)
                        continue;
                    if (isFirstAppend)
                    {
                        isFirstAppend = false;
                        handler.AppendLiteral("?");
                    }
                    else
                        handler.AppendLiteral("&");
                    int count;
                    ReadOnlySpan<char> nameAsSpan = propertyInfo.Name.AsSpan();
                    while ((count = nameAsSpan.ToLower(lowerCaseBuffer, null)) == -1)
                    {
                        int newBufferLength = Math.Max(propertyInfo.Name.Length, lowerCaseBuffer.Length * 2);
                        lowerCaseBuffer = new char[newBufferLength];
                    }
#pragma warning disable CS9080 // Use of variable in this context may expose referenced variables outside of their declaration scope
                    handler.AppendFormatted(lowerCaseBuffer.Slice(0, count));
#pragma warning restore CS9080 // Use of variable in this context may expose referenced variables outside of their declaration scope
                    handler.AppendLiteral("=");
                    handler.AppendFormatted(value);
                }
                return handler.ToStringAndClear();
            }
        }

        /// <summary>
        /// Convert typed object into HTTP query parameter string. Passing an untyped object will 
        /// return a empty string.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="typeValue"></param>
        /// <returns></returns>
        public static string ToQuery<T>(T typeValue)
            => Adapter<T>.ToQuery(typeValue);

        public static T ToType<T>(string query)
        {
            throw new NotImplementedException();
        }
    }
}
