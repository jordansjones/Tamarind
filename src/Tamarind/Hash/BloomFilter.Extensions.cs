using System;
using System.Collections;
using System.Linq;

using Tamarind.Primitives;

namespace Tamarind.Hash
{
    internal static class BloomFilterExtensions
    {

        public static long BitSize(this BitArray This)
        {
            return This.Length * Longs.BitCount;
        }

    }
}
