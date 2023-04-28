using System.Text;
using System.Text.Json;

namespace BlossomiShymae.RiotBlossom.Core
{
    /// <summary>
    /// A helper class used for prettifying strings.
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
        /// <para>Get the pretty string of object, hehe!</para>
        /// </summary>
        /// <exception cref="NotSupportedException"></exception>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string GetString<T>(T obj) where T : notnull
        {
            StringBuilder sb = new();
            System.Type type = typeof(T);
            sb.Append(type.Name);
            if (type.IsGenericType)
            {
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
    }
}
