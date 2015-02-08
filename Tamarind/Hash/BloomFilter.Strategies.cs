using System;
using System.Collections;
using System.Linq;

namespace Tamarind.Hash
{

    internal class Murmur128Mitz32Strategy : IBloomFilterStrategy
    {


        public bool MightContain<T>(T @object, IFunnel<T> funnel, int numHashFunctions, BitArray bits)
        {
            throw new NotImplementedException();
        }

        public bool Write<T>(T @object, IFunnel<T> funnel, int numHashFunctions, BitArray bits)
        {
            throw new NotImplementedException();
        }

    }

    internal class Murmur128Mitz64Strategy : IBloomFilterStrategy
    {

        public bool MightContain<T>(T @object, IFunnel<T> funnel, int numHashFunctions, BitArray bits)
        {
            throw new NotImplementedException();
        }

        public bool Write<T>(T @object, IFunnel<T> funnel, int numHashFunctions, BitArray bits)
        {
//            var bitSize = bits.BitSize();
            throw new NotImplementedException();
        }

    }
}
