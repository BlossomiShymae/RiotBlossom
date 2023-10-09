using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlossomiShymae.RiotBlossom.Core.Utils
{
    public abstract record ValueEnum<T>
    {
        public T Value { get; }

        public ValueEnum(T value)
        {
            Value = value;
        }
    }
}