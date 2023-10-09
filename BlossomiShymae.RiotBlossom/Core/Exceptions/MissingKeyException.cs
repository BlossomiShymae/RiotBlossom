using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlossomiShymae.RiotBlossom.Core.Exceptions
{
    public class MissingKeyException : System.Exception
    {
        public MissingKeyException() : base("API key not set!")
        {
        }
    }
}