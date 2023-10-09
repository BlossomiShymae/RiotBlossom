using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlossomiShymae.RiotBlossom.Core.Exceptions
{
    public class OutdatedTypeException : System.Exception
    {
        public OutdatedTypeException() : base("This ")
        {
        }
    }
}