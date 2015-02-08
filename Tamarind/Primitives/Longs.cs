using System;
using System.Linq;

namespace Tamarind.Primitives
{
    public static class Longs
    {

        /// <summary>
        ///     Number of bits used to represent a <see cref="long" /> value in two's complement binary form.
        /// </summary>
        public const int BitCount = ByteCount * Bytes.BitCount;

        /// <summary>
        ///     Number of bytes used to represent a <see cref="long" /> value in two's complement binary form.
        /// </summary>
        public const int ByteCount = sizeof (long);

    }
}
