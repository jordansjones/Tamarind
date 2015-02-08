using System;
using System.Collections;
using System.Linq;

using Tamarind.Core;
using Tamarind.Primitives;

namespace Tamarind.Hash
{
    /// <summary>
    ///     A Bloom filter offers an approximate containment test with one-sided error:
    ///     if it claims that an element is contained in it, this might be in error, but
    ///     if it claims that an element is <em>not</em> contained in it, then this is
    ///     definitely true.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         If you are unfamiliar with Bloom filters, this nice
    ///         <a href="http://llimllib.github.com/bloomfilter-tutorial">tutorial</a>
    ///         may help you understand how they work.
    ///     </para>
    ///     <para>
    ///         The false positive probability (<c>FPP</c>) of a bloom filter is defined as the probability
    ///         that <see cref="MightContain(T)" /> will erroneously return <c>true</c> for an object that
    ///         has not actually been put in the <see cref="BloomFilter{T}" />.
    ///     </para>
    /// </remarks>
    /// <typeparam name="T">the type of instances that the <c>BloomFilter</c> accepts</typeparam>
    public sealed class BloomFilter<T>
    {

        /// <summary>
        ///     The bit set of the BloomFilter (not necessarily power of 2)
        /// </summary>
        private readonly BitArray bits;

        /// <summary>
        ///     The funnel to translate <typeparamref name="T" />s to bytes
        /// </summary>
        private readonly IFunnel<T> funnel;

        /// <summary>
        ///     Number of hashes per element
        /// </summary>
        private readonly int numberOfHashFunctions;

        /// <summary>
        ///     The strategy to employ when mapping an element <typeparamref name="T" /> to
        ///     <seealso cref="numberOfHashFunctions" /> bit indexes.
        /// </summary>
        private readonly IBloomFilterStrategy strategy;

        private BloomFilter(BitArray bits, int numberOfHashFunctions, IFunnel<T> funnel, IBloomFilterStrategy strategy)
        {
            Preconditions.CheckArgument(numberOfHashFunctions > 0, "numberOfHashFunctions", "numberOfHashFunctions {0} must be > 0", numberOfHashFunctions);
            Preconditions.CheckArgument(numberOfHashFunctions <= 255, "numberOfHashFunctions", "numberOfHashFunctions {0} must be <= 255", numberOfHashFunctions);

            this.bits = Preconditions.CheckNotNull(bits);
            this.numberOfHashFunctions = numberOfHashFunctions;
            this.funnel = Preconditions.CheckNotNull(funnel);
            this.strategy = Preconditions.CheckNotNull(strategy);
        }

        /// <summary>
        ///     Number for set bits
        /// </summary>
        internal long BitCount { get; private set; }

        /// <summary>
        ///     Number of bits
        /// </summary>
        internal long BitSize
        {
            get { return bits.BitSize(); }
        }

        /// <summary>
        ///     (Expected False Positive Probability) Returns the probability that <see cref="MightContain(T)" /> will erroneously
        ///     return
        ///     <c>true</c> for an object that has not actually been put in the <see cref="BloomFilter{T}" />.
        /// </summary>
        public double ExpectedFpp
        {
            get { return System.Math.Pow((double) BitCount / BitSize, numberOfHashFunctions); }
        }

        /// <summary>
        ///     Adds an element into this <see cref="BloomFilter{T}" />. Ensures that the subsequent invocations of
        ///     <see cref="MightContain(T)" /> with the same element will always return <c>true</c>.
        /// </summary>
        /// <returns>
        ///     <c>true</c> if the bloom filter's bits changed as a result of this operation. If the bits
        ///     changed, this is <em>definitely</em> the first time <paramref name="object" /> has been added to the
        ///     filter. If the bits haven't changed, this <em>might</em> be the first time <paramref name="object" />
        ///     has been added to the filter. Note that <see cref="Add(T)" /> always returns the <em>opposite</em> result
        ///     to what <see cref="MightContain(T)" /> would have returned at the time it is called.
        /// </returns>
        public bool Add(T @object)
        {
            return strategy.Write(@object, funnel, numberOfHashFunctions, bits);
        }

        /// <summary>
        ///     Creates a new <see cref="BloomFilter{T}" /> that's a copy of this instance. The new instance is equal to this
        ///     instance but shares no mutable state.
        /// </summary>
        public BloomFilter<T> Copy()
        {
            return new BloomFilter<T>(
                new BitArray(bits),
                numberOfHashFunctions,
                funnel,
                strategy
                );
        }

        /// <summary>
        ///     Returns <c>true</c> if the element <em>might</em> have been put in this Bloom filter,
        ///     <c>false</c> if this is <em>definitely</em> not the case.
        /// </summary>
        public bool MightContain(T @object)
        {
            return strategy.MightContain(@object, funnel, numberOfHashFunctions, bits);
        }

        // ReSharper disable once StaticMemberInGenericType
        private static readonly IBloomFilterStrategy DefaultStrategy = new Murmur128Mitz64Strategy();

        /// <summary>
        ///     Creates a <see cref="BloomFilter{T}" /> with the expected number of insertions and
        ///     expected false positive probability.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         Note that overflowing a <see cref="BloomFilter{T}" /> with significantly more elements
        ///         than specified, will result in its saturation, and a sharp deterioration of its false
        ///         positive probability.
        ///     </para>
        /// </remarks>
        /// <param name="funnel">
        ///     The funnel of <typeparamref name="TItem" />'s that the constructed <seealso cref="BloomFilter{T}" />
        ///     will use.
        /// </param>
        /// <param name="expectedInsertions">
        ///     The number of expected insertions to the constructed <see cref="BloomFilter{T}" />;
        ///     must be positive.
        /// </param>
        /// <param name="fpp">The desired false positive probability (must be positive and less than 1.0)</param>
        /// <returns>A <see cref="BloomFilter{T}" />.</returns>
        public static BloomFilter<TItem> Create<TItem>(IFunnel<TItem> funnel, int expectedInsertions, double fpp)
        {
            Preconditions.CheckArgument(expectedInsertions >= 0, "expectedInsertions", "Expected insertions ({0}) must be >= 0", expectedInsertions);
            Preconditions.CheckArgument(fpp > 0.0, "fpp", "False positive probability ({0}) must be > 0.0", fpp);
            Preconditions.CheckArgument(fpp < 1.0, "fpp", "False positive probability ({0}) must be < 1.0", fpp);
            return Create(funnel, expectedInsertions, fpp, DefaultStrategy);
        }

        internal static BloomFilter<TItem> Create<TItem>(IFunnel<TItem> funnel, int expectedInsertions, double fpp, IBloomFilterStrategy strategy)
        {
            Preconditions.CheckNotNull(funnel);

            expectedInsertions = expectedInsertions != 0 ? expectedInsertions : 1;
            var numBits = OptimalNumberOfBits(expectedInsertions, fpp);
            var numHashFuncs = OptimalNumberOfHashFunctions(expectedInsertions, numBits);
            try
            {
                return new BloomFilter<TItem>(new BitArray(numBits), numHashFuncs, funnel, strategy);
            }
            catch (ArgumentOutOfRangeException e)
            {
                throw new ArgumentException("Could not create BloomFilter of " + numBits + " bits", e);
            }
        }

        /// <summary>
        ///     Computes m (total bits of a bloom filter) which is expected to achieve, for the specified
        ///     expected insertions, the required false positive probability.
        ///     <para>
        ///         See http://en.wikipedia.org/wiki/Bloom_filter#Probability_of_false_positives for the formula.
        ///     </para>
        /// </summary>
        /// <param name="n">Expected insertions (must be positive).</param>
        /// <param name="p">False positive rate (must be 0 &lt; p &lt; 1).</param>
        internal static int OptimalNumberOfBits(long n, double p)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            if (p == 0.0)
            {
                p = double.MinValue;
            }
            return (int) (-n * System.Math.Log(p) / (System.Math.Log(2) * System.Math.Log(2)));
        }

        /// <summary>
        ///     Computes the optimal k (number of hases per element inserted in the bloom filter), given the
        ///     expected insertions and totoal number of bits in the bloom filter.
        ///     <para>
        ///         See http://en.wikipedia.org/wiki/File:Bloom_filter_fp_probability.svg for the formula.
        ///     </para>
        /// </summary>
        /// <param name="n">Expected insertions (must be positive).</param>
        /// <param name="m">Total number of bits in the bloom filter (must be positive).</param>
        /// <returns></returns>
        internal static int OptimalNumberOfHashFunctions(long n, long m)
        {
            return System.Math.Max(1, (int) System.Math.Round((double) m / n * System.Math.Log(2)));
        }

    }
}
