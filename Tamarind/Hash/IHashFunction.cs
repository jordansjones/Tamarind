using System;
using System.Linq;
using System.Text;

namespace Tamarind.Hash
{
    /// <summary>
    ///     A has function is a collision-averse pure function that maps an arbitrary block of
    ///     data to a number called a <em>has code</em>.
    /// </summary>
    public interface IHashFunction
    {

        /// <summary>
        ///     The number of bits (a multiple of 32) that each hash code produced
        ///     by this hash function has.
        /// </summary>
        int Bits { get; }

        /// <summary>
        ///     Begins a new hash code computation by returning an initialized, stateful
        ///     <see cref="IHasher" /> instance that is read to receive data.
        /// </summary>
        /// <example>
        ///     <code>
        /// long id = 1;
        /// bool isActive = true;
        /// ...
        /// HashCode hash = Hashing.Md5.New()
        ///     .Write(id)
        ///     .Write(isActive)
        ///     .Hash();
        /// </code>
        /// </example>
        /// <param name="expectedInputSize">
        ///     Provides a hint of the expected
        ///     size of the input (in bytes). This is only important for
        ///     non-streaming hash functions (hash functions that need to buffer
        ///     their whole input before processing any of it).
        /// </param>
        IHasher NewHasher(int? expectedInputSize = null);

        /// <summary>
        ///     Shortcut for <c>NewHasher().Write(input).Hash()</c>. The
        ///     implementation <em>might</em> perform better that its longhand
        ///     equivalent, but should not perform worse.
        /// </summary>
        /// <exception cref="IndexOutOfRangeException">
        ///     if <c><paramref name="index" /> &lt; 0</c> or
        ///     <c><paramref name="index" /> + <paramref name="count" /> &gt; <paramref name="input" />.Length</c>
        ///     or <c><paramref name="count" /> &lt; 0</c> (when <paramref name="index" /> and/or <paramref name="count" /> are
        ///     supplied)
        /// </exception>
        HashCode Hash(byte[] input, int? index = null, int? count = null);

        /// <summary>
        ///     Shortcut for <c>NewHasher().Write(input).Hash()</c>; returns the hash code
        ///     for <paramref name="input" />.
        ///     The implementation <em>might</em> perform better than its longhand
        ///     equivalent, but should not perform worse.
        /// </summary>
        HashCode Hash(int input);

        /// <summary>
        ///     Shortcut for <c>NewHasher().Write(input).Hash()</c>; returns the hash code
        ///     for <paramref name="input" />.
        ///     The implementation <em>might</em> perform better than its longhand
        ///     equivalent, but should not perform worse.
        /// </summary>
        HashCode Hash(long input);

        /// <summary>
        ///     Shortcut for <c>NewHasher().Write(input).Hash()</c>. The
        ///     implementation <em>might</em> perform better that its longhand
        ///     equivalent, but should not perform worse. Note that no character
        ///     encoding is performed.
        /// </summary>
        /// <exception cref="IndexOutOfRangeException">
        ///     if <c><paramref name="index" /> &lt; 0</c> or
        ///     <c><paramref name="index" /> + <paramref name="count" /> &gt; <paramref name="input" />.Length</c>
        ///     or <c><paramref name="count" /> &lt; 0</c> (when <paramref name="index" /> and/or <paramref name="count" /> are
        ///     supplied)
        /// </exception>
        HashCode Hash(char[] input, int? index = null, int? count = null);

        /// <summary>
        ///     Shortcut for <c>NewHasher().Write(input).Hash()</c>. Characters are
        ///     encoded using the given <see cref="System.Text.Encoding" />. The
        ///     implementation <em>might</em> perform better than its longhand
        ///     equivalent, but should not perform worse.
        /// </summary>
        HashCode Hash(string input, Encoding encoding);

        /// <summary>
        ///     Shortcut for <c>NewHasher().Write(object, funnel).Hash()</c>. The
        ///     implementation <em>might</em> perform better than its longhand
        ///     equivalent, but should not perform worse.
        /// </summary>
        HashCode Hash<T>(T @object, IFunnel<T> funnel);

    }
}
