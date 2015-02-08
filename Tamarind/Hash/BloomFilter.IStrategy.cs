using System;
using System.Collections;
using System.Linq;

namespace Tamarind.Hash
{
    internal interface IBloomFilterStrategy
    {

        bool MightContain<T>(T @object, IFunnel<T> funnel, int numHashFunctions, BitArray bits);

        bool Write<T>(T @object, IFunnel<T> funnel, int numHashFunctions, BitArray bits);

    }
}
