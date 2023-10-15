using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlossomiShymae.RiotBlossom.Core.Exceptions
{
    public class RetryingException : System.Exception
    {
        public RetryingException() : base("Failed to retry API request!")
        {
        }
    }
}