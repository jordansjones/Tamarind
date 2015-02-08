using System;
using System.Linq;

namespace Tamarind.Hash
{
    /// <summary>
    ///     An object which can send data from an object of type <typeparamref name="T" /> into an
    ///     <see cref="IPrimitiveSink" />.
    ///     Implementations for common types can be found in <see cref="Funnels" />.
    /// </summary>
    public interface IFunnel<in T>
    {

        /// <summary>
        ///     Sends a stream of data from the <paramref name="from" /> object into the sink <paramref name="into" />.
        ///     There is no requirement that this data be complete enough to fully reconstitute the object later.
        /// </summary>
        void Funnel(T from, IPrimitiveSink into);

    }
}
