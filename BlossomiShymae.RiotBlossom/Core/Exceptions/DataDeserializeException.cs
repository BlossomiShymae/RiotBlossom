using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlossomiShymae.RiotBlossom.Core.Exceptions
{
    public class DataDeserializeException : System.Exception
    {
        public DataDeserializeException() : base("Unable to deserialize data from API...")
        {
        }
    }
}