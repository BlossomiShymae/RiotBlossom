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
        public static string GetString(object obj)
            => JsonSerializer.Serialize(obj, options: s_options);
    }
}
