using System.Text;
using System.Text.Json;

namespace BlossomiShymae.RiotBlossom.Core
{
    /// <summary>
    /// A helper class used for getting pretty printed strings.
    /// </summary>
    public static class PrettyPrinter
    {
        private static readonly JsonSerializerOptions s_options = new()
        {
            WriteIndented = true,
            AllowTrailingCommas = true,
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

        /// <summary>
        /// <para>Get the pretty string of object with manual class name, hehe!</para>
        /// <para>Note: Field names will be printed into camel case or into JsonPropertyName attribute.</para>
        /// </summary>
        /// <exception cref="NotSupportedException"></exception>
        /// <param name="obj"></param>
        /// <param name="className"></param>
        /// <returns></returns>
        public static string GetString<T>(T obj, string? className) where T : notnull
        {
            StringBuilder sb = new();
            System.Type type = typeof(T);
            if (className != null)
            {
                sb.Append(className);
            }
            else if (type.IsGenericType)
            {
                sb.Append(type.Name);
                sb.Append('[');
                System.Type[] typeArguments = type.GetGenericArguments();
                for (int i = 0; i < typeArguments.Length; i++)
                {
                    sb.Append(typeArguments[i].Name);
                    if (i != typeArguments.Length - 1)
                        sb.Append(new char[] { ',', ' ' });
                }
                sb.Append(']');
            }
            sb.Append(' ');
            sb.Append(JsonSerializer.Serialize((object)obj, options: s_options));

            return sb.ToString();
        }

        /// <summary>
        /// <para>Get the pretty string of object, hehe!</para>
        /// <para>Note: Field names will be printed into camel case or into JsonPropertyName attribute.</para>
        /// </summary>
        /// <exception cref="NotSupportedException"></exception>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string GetString<T>(T obj) where T : notnull
            => GetString(obj, null);
    }
}
