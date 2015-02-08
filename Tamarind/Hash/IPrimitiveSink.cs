using System;
using System.Linq;
using System.Text;

namespace Tamarind.Hash
{
    /// <summary>
    ///     An object which can receive a stream of primitive values.
    /// </summary>
    public interface IPrimitiveSink
    {
        #region string

        /// <summary>
        ///     Writes a string into this sink.
        /// </summary>
        /// <param name="value">The string to write.</param>
        /// <param name="encoding">The encoding to use. Defaults to <see cref="System.Text.Encoding.UTF8" />.</param>
        /// <returns>This instance.</returns>
        IPrimitiveSink Write(string value, Encoding encoding = null);

        #endregion

        #region byte

        /// <summary>
        ///     Writes a byte into this sink.
        /// </summary>
        /// <param name="value">The byte to write.</param>
        /// <returns>This instance.</returns>
        IPrimitiveSink Write(byte value);

        /// <summary>
        ///     Writes a chunk, or the whole, array of bytes into this sink.
        /// </summary>
        /// <param name="values">A byte array containing the data to write.</param>
        /// <param name="index">
        ///     The starting point in <paramref name="values" /> at which to begin writing.
        ///     Defaults to <c>0</c>
        /// </param>
        /// <param name="count">
        ///     The number of bytes to write.
        ///     Defaults to <c><paramref name="values" />.Length</c>
        /// </param>
        /// <returns>This instance.</returns>
        /// <exception cref="IndexOutOfRangeException">
        ///     if <c><paramref name="index" /> &lt; 0</c> or
        ///     <c><paramref name="index" /> + <paramref name="count" /> &gt; <paramref name="values" />.Length</c>
        ///     or <c><paramref name="count" /> &lt; 0</c> (when <paramref name="index" /> and/or <paramref name="count" /> are
        ///     supplied)
        /// </exception>
        IPrimitiveSink Write(byte[] values, int? index = null, int? count = null);

        #endregion

        #region short

        /// <summary>
        ///     Writes a short into this sink.
        /// </summary>
        /// <param name="value">The short to write.</param>
        /// <returns>This instance.</returns>
        IPrimitiveSink Write(short value);

        /// <summary>
        ///     Writes a chunk, or the whole, array of shorts into this sink.
        /// </summary>
        /// <param name="values">A short array containing the data to write.</param>
        /// <param name="index">
        ///     The starting point in <paramref name="values" /> at which to begin writing.
        ///     Defaults to <c>0</c>
        /// </param>
        /// <param name="count">
        ///     The number of shorts to write.
        ///     Defaults to <c><paramref name="values" />.Length</c>
        /// </param>
        /// <returns>This instance.</returns>
        /// <exception cref="IndexOutOfRangeException">
        ///     if <c><paramref name="index" /> &lt; 0</c> or
        ///     <c><paramref name="index" /> + <paramref name="count" /> &gt; <paramref name="values" />.Length</c>
        ///     or <c><paramref name="count" /> &lt; 0</c> (when <paramref name="index" /> and/or <paramref name="count" /> are
        ///     supplied)
        /// </exception>
        IPrimitiveSink Write(short[] values, int? index = null, int? count = null);

        #endregion

        #region int

        /// <summary>
        ///     Writes an int into this sink.
        /// </summary>
        /// <param name="value">The int to write.</param>
        /// <returns>This instance.</returns>
        IPrimitiveSink Write(int value);

        /// <summary>
        ///     Writes a chunk, or the whole, array of ints into this sink.
        /// </summary>
        /// <param name="values">An int array containing the data to write.</param>
        /// <param name="index">
        ///     The starting point in <paramref name="values" /> at which to begin writing.
        ///     Defaults to <c>0</c>
        /// </param>
        /// <param name="count">
        ///     The number of ints to write.
        ///     Defaults to <c><paramref name="values" />.Length</c>
        /// </param>
        /// <returns>This instance.</returns>
        /// <exception cref="IndexOutOfRangeException">
        ///     if <c><paramref name="index" /> &lt; 0</c> or
        ///     <c><paramref name="index" /> + <paramref name="count" /> &gt; <paramref name="values" />.Length</c>
        ///     or <c><paramref name="count" /> &lt; 0</c> (when <paramref name="index" /> and/or <paramref name="count" /> are
        ///     supplied)
        /// </exception>
        IPrimitiveSink Write(int[] values, int? index = null, int? count = null);

        #endregion

        #region long

        /// <summary>
        ///     Writes a long into this sink.
        /// </summary>
        /// <param name="value">The long to write.</param>
        /// <returns>This instance.</returns>
        IPrimitiveSink Write(long value);

        /// <summary>
        ///     Writes a chunk, or the whole, array of longs into this sink.
        /// </summary>
        /// <param name="values">A long array containing the data to write.</param>
        /// <param name="index">
        ///     The starting point in <paramref name="values" /> at which to begin writing.
        ///     Defaults to <c>0</c>
        /// </param>
        /// <param name="count">
        ///     The number of longs to write.
        ///     Defaults to <c><paramref name="values" />.Length</c>
        /// </param>
        /// <returns>This instance.</returns>
        /// <exception cref="IndexOutOfRangeException">
        ///     if <c><paramref name="index" /> &lt; 0</c> or
        ///     <c><paramref name="index" /> + <paramref name="count" /> &gt; <paramref name="values" />.Length</c>
        ///     or <c><paramref name="count" /> &lt; 0</c> (when <paramref name="index" /> and/or <paramref name="count" /> are
        ///     supplied)
        /// </exception>
        IPrimitiveSink Write(long[] values, int? index = null, int? count = null);

        #endregion

        #region float

        /// <summary>
        ///     Writes a float into this sink.
        /// </summary>
        /// <param name="value">The float to write.</param>
        /// <returns>This instance.</returns>
        IPrimitiveSink Write(float value);

        /// <summary>
        ///     Writes a chunk, or the whole, array of floats into this sink.
        /// </summary>
        /// <param name="values">A float array containing the data to write.</param>
        /// <param name="index">
        ///     The starting point in <paramref name="values" /> at which to begin writing.
        ///     Defaults to <c>0</c>
        /// </param>
        /// <param name="count">
        ///     The number of floats to write.
        ///     Defaults to <c><paramref name="values" />.Length</c>
        /// </param>
        /// <returns>This instance.</returns>
        /// <exception cref="IndexOutOfRangeException">
        ///     if <c><paramref name="index" /> &lt; 0</c> or
        ///     <c><paramref name="index" /> + <paramref name="count" /> &gt; <paramref name="values" />.Length</c>
        ///     or <c><paramref name="count" /> &lt; 0</c> (when <paramref name="index" /> and/or <paramref name="count" /> are
        ///     supplied)
        /// </exception>
        IPrimitiveSink Write(float[] values, int? index = null, int? count = null);

        #endregion

        #region decimal

        /// <summary>
        ///     Writes a decimal into this sink.
        /// </summary>
        /// <param name="value">The decimal to write.</param>
        /// <returns>This instance.</returns>
        IPrimitiveSink Write(decimal value);

        /// <summary>
        ///     Writes a chunk, or the whole, array of decimals into this sink.
        /// </summary>
        /// <param name="values">A decimal array containing the data to write.</param>
        /// <param name="index">
        ///     The starting point in <paramref name="values" /> at which to begin writing.
        ///     Defaults to <c>0</c>
        /// </param>
        /// <param name="count">
        ///     The number of decimals to write.
        ///     Defaults to <c><paramref name="values" />.Length</c>
        /// </param>
        /// <returns>This instance.</returns>
        /// <exception cref="IndexOutOfRangeException">
        ///     if <c><paramref name="index" /> &lt; 0</c> or
        ///     <c><paramref name="index" /> + <paramref name="count" /> &gt; <paramref name="values" />.Length</c>
        ///     or <c><paramref name="count" /> &lt; 0</c> (when <paramref name="index" /> and/or <paramref name="count" /> are
        ///     supplied)
        /// </exception>
        IPrimitiveSink Write(decimal[] values, int? index = null, int? count = null);

        #endregion

        #region double

        /// <summary>
        ///     Writes a double into this sink.
        /// </summary>
        /// <param name="value">The byte to write.</param>
        /// <returns>This instance.</returns>
        IPrimitiveSink Write(double value);

        /// <summary>
        ///     Writes a chunk, or the whole, array of doubles into this sink.
        /// </summary>
        /// <param name="values">A double array containing the data to write.</param>
        /// <param name="index">
        ///     The starting point in <paramref name="values" /> at which to begin writing.
        ///     Defaults to <c>0</c>
        /// </param>
        /// <param name="count">
        ///     The number of doubles to write.
        ///     Defaults to <c><paramref name="values" />.Length</c>
        /// </param>
        /// <returns>This instance.</returns>
        /// <exception cref="IndexOutOfRangeException">
        ///     if <c><paramref name="index" /> &lt; 0</c> or
        ///     <c><paramref name="index" /> + <paramref name="count" /> &gt; <paramref name="values" />.Length</c>
        ///     or <c><paramref name="count" /> &lt; 0</c> (when <paramref name="index" /> and/or <paramref name="count" /> are
        ///     supplied)
        /// </exception>
        IPrimitiveSink Write(double[] values, int? index = null, int? count = null);

        #endregion

        #region bool

        /// <summary>
        ///     Writes a bool into this sink.
        /// </summary>
        /// <param name="value">The bool to write.</param>
        /// <returns>This instance.</returns>
        IPrimitiveSink Write(bool value);

        /// <summary>
        ///     Writes a chunk, or the whole, array of bools into this sink.
        /// </summary>
        /// <param name="values">A bool array containing the data to write.</param>
        /// <param name="index">
        ///     The starting point in <paramref name="values" /> at which to begin writing.
        ///     Defaults to <c>0</c>
        /// </param>
        /// <param name="count">
        ///     The number of bools to write.
        ///     Defaults to <c><paramref name="values" />.Length</c>
        /// </param>
        /// <returns>This instance.</returns>
        /// <exception cref="IndexOutOfRangeException">
        ///     if <c><paramref name="index" /> &lt; 0</c> or
        ///     <c><paramref name="index" /> + <paramref name="count" /> &gt; <paramref name="values" />.Length</c>
        ///     or <c><paramref name="count" /> &lt; 0</c> (when <paramref name="index" /> and/or <paramref name="count" /> are
        ///     supplied)
        /// </exception>
        IPrimitiveSink Write(bool[] values, int? index = null, int? count = null);

        #endregion

        #region char

        /// <summary>
        ///     Writes a char into this sink.
        /// </summary>
        /// <param name="value">The char to write.</param>
        /// <returns>This instance.</returns>
        IPrimitiveSink Write(char value);

        /// <summary>
        ///     Writes a chunk, or the whole, array of chars into this sink.
        /// </summary>
        /// <param name="values">A char array containing the data to write.</param>
        /// <param name="index">
        ///     The starting point in <paramref name="values" /> at which to begin writing.
        ///     Defaults to <c>0</c>
        /// </param>
        /// <param name="count">
        ///     The number of chars to write.
        ///     Defaults to <c><paramref name="values" />.Length</c>
        /// </param>
        /// <returns>This instance.</returns>
        /// <exception cref="IndexOutOfRangeException">
        ///     if <c><paramref name="index" /> &lt; 0</c> or
        ///     <c><paramref name="index" /> + <paramref name="count" /> &gt; <paramref name="values" />.Length</c>
        ///     or <c><paramref name="count" /> &lt; 0</c> (when <paramref name="index" /> and/or <paramref name="count" /> are
        ///     supplied)
        /// </exception>
        IPrimitiveSink Write(char[] values, int? index = null, int? count = null);

        #endregion
    }
}
