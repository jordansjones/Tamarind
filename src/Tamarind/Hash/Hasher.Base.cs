using System;
using System.Linq;
using System.Text;

using Tamarind.Core;

namespace Tamarind.Hash
{
    /// <summary>
    ///     Abstract hasher, implementing the following:
    ///     <list type="bullet">
    ///         <item>
    ///             <description>
    ///                 <see cref="Write(bool)" />
    ///             </description>
    ///         </item>
    ///         <item>
    ///             <description>
    ///                 <see cref="Write(char[], int?, int?)" />
    ///             </description>
    ///         </item>
    ///         <item>
    ///             <description>
    ///                 <see cref="Write(decimal)" />
    ///             </description>
    ///         </item>
    ///         <item>
    ///             <description>
    ///                 <see cref="Write(double)" />
    ///             </description>
    ///         </item>
    ///         <item>
    ///             <description>
    ///                 <see cref="Write(float)" />
    ///             </description>
    ///         </item>
    ///         <item>
    ///             <description>
    ///                 <see cref="Write(string, Encoding)" />
    ///             </description>
    ///         </item>
    ///     </list>
    /// </summary>
    internal abstract class BaseHasher : IHasher
    {

        public abstract IHasher Write(byte value);

        public abstract IHasher Write(byte[] values, int? index = null, int? count = null);

        public abstract IHasher Write(short value);

        public abstract IHasher Write(short[] values, int? index = null, int? count = null);

        public abstract IHasher Write(int value);

        public abstract IHasher Write(int[] values, int? index = null, int? count = null);

        public abstract IHasher Write(long value);

        public abstract IHasher Write(long[] values, int? index = null, int? count = null);

        public IHasher Write(float value)
        {
            return Write(BitConverter.GetBytes(value));
        }

        public abstract IHasher Write(float[] values, int? index = null, int? count = null);

        public IHasher Write(decimal value)
        {
            return Write(decimal.GetBits(value));
        }

        public abstract IHasher Write(decimal[] values, int? index = null, int? count = null);

        public IHasher Write(double value)
        {
            return Write(BitConverter.DoubleToInt64Bits(value));
        }

        public abstract IHasher Write(double[] values, int? index = null, int? count = null);

        public IHasher Write(bool value)
        {
            return Write(value ? (byte) 1 : (byte) 0);
        }

        public abstract IHasher Write(bool[] values, int? index = null, int? count = null);

        public abstract IHasher Write(char value);

        public IHasher Write(char[] values, int? index = null, int? count = null)
        {
            var offset = index ?? 0;
            var length = count ?? values.Length;

            Preconditions.CheckPositionIndexes(offset, length, values.Length);

            for (var i = offset; i < offset + length; i++)
            {
                Write(values[i]);
            }
            return this;
        }

        public abstract IHasher Write<T>(T @object, IFunnel<T> funnel);

        public IHasher Write(string value, Encoding encoding = null)
        {
            encoding = encoding ?? Encoding.UTF8;
            return Write(encoding.GetBytes(value));
        }

        public abstract HashCode Hash();

        #region IPrimitiveSink Implementation

        IPrimitiveSink IPrimitiveSink.Write(byte value)
        {
            return Write(value);
        }

        IPrimitiveSink IPrimitiveSink.Write(byte[] values, int? index, int? count)
        {
            return Write(values, index, count);
        }

        IPrimitiveSink IPrimitiveSink.Write(short value)
        {
            return Write(value);
        }

        IPrimitiveSink IPrimitiveSink.Write(short[] values, int? index, int? count)
        {
            return Write(values, index, count);
        }

        IPrimitiveSink IPrimitiveSink.Write(int value)
        {
            return Write(value);
        }

        IPrimitiveSink IPrimitiveSink.Write(int[] values, int? index, int? count)
        {
            return Write(values, index, count);
        }

        IPrimitiveSink IPrimitiveSink.Write(long value)
        {
            return Write(value);
        }

        IPrimitiveSink IPrimitiveSink.Write(long[] values, int? index, int? count)
        {
            return Write(values, index, count);
        }

        IPrimitiveSink IPrimitiveSink.Write(float value)
        {
            return Write(value);
        }

        IPrimitiveSink IPrimitiveSink.Write(float[] values, int? index, int? count)
        {
            return Write(values, index, count);
        }

        IPrimitiveSink IPrimitiveSink.Write(decimal value)
        {
            return Write(value);
        }

        IPrimitiveSink IPrimitiveSink.Write(decimal[] values, int? index, int? count)
        {
            return Write(values, index, count);
        }

        IPrimitiveSink IPrimitiveSink.Write(double value)
        {
            return Write(value);
        }

        IPrimitiveSink IPrimitiveSink.Write(double[] values, int? index, int? count)
        {
            return Write(values, index, count);
        }

        IPrimitiveSink IPrimitiveSink.Write(bool value)
        {
            return Write(value);
        }

        IPrimitiveSink IPrimitiveSink.Write(bool[] values, int? index, int? count)
        {
            return Write(values, index, count);
        }

        IPrimitiveSink IPrimitiveSink.Write(char value)
        {
            return Write(value);
        }

        IPrimitiveSink IPrimitiveSink.Write(char[] values, int? index, int? count)
        {
            return Write(values, index, count);
        }

        IPrimitiveSink IPrimitiveSink.Write(string value, Encoding encoding)
        {
            return Write(value, encoding);
        }

        #endregion
    }
}
