using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlossomiShymae.RiotBlossom.Core.Utils
{
    public class NamedFormatter(string placeholder)
    {
        private readonly string _placeholder = placeholder;

        public string Format(IDictionary<string, string> dict)
        {
            var fmt = new string(_placeholder);
            var query = "";

            foreach (var kv in dict)
            {
                var template = kv.Key;

                if (fmt.Contains(template))
                {
                    fmt = fmt.Replace(template, kv.Value);
                }
                else
                {
                    if (query.Length == 0)
                    {
                        query += $"?{kv.Key}={kv.Value}";
                    }
                    else
                    {
                        query += $"&{kv.Key}={kv.Value}";
                    }
                }
            }

            return $"{fmt}{query.ToLower()}";
        }
    }
}