using System;
using System.Collections.Generic;
using System.Text;

namespace BetterLinq
{
    public sealed class Indexed<T>
    {
        public Indexed(int index, T value)
        {
            this.Index = index;
            this.Value = value;
        }

        public int Index { get; }

        public T Value { get; }
    }
}
