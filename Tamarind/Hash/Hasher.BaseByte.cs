using System;
using System.Linq;

using Tamarind.Core;

namespace Tamarind.Hash
{
    internal abstract class BaseByteHasher : BaseHasher
    {

        protected abstract void Update(byte b);

        protected void Update(byte[] b)
        {
            Update(b, 0, b.Length);
        }

        protected void Update(byte[] b, int index, int count)
        {
            for (var i = index; i < index + count; i++)
            {
                Update(b[i]);
            }
        }

        public override IHasher Write(byte value)
        {
            Update(value);
            return this;
        }

        public override IHasher Write(byte[] values, int? index = null, int? count = null)
        {
            var offset = index ?? 0;
            var length = count ?? values.Length;

            Preconditions.CheckPositionIndexes(offset, length, values.Length);
            Update(values, offset, length);
            return this;
        }

        public override IHasher Write(short value)
        {
            Update(BitConverter.GetBytes(value));
            return this;
        }

        public override IHasher Write(short[] values, int? index = null, int? count = null)
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

        public override IHasher Write(int value)
        {
            Update(BitConverter.GetBytes(value));
            return this;
        }

        public override IHasher Write(int[] values, int? index = null, int? count = null)
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

        public override IHasher Write(long value)
        {
            Update(BitConverter.GetBytes(value));
            return this;
        }

        public override IHasher Write(long[] values, int? index = null, int? count = null)
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

        public override IHasher Write(float[] values, int? index = null, int? count = null)
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

        public override IHasher Write(decimal[] values, int? index = null, int? count = null)
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

        public override IHasher Write(double[] values, int? index = null, int? count = null)
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

        public override IHasher Write(bool[] values, int? index = null, int? count = null)
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

        public override IHasher Write(char value)
        {
            Update(BitConverter.GetBytes(value));
            return this;
        }

        public override IHasher Write<T>(T @object, IFunnel<T> funnel)
        {
            Preconditions.CheckNotNull(funnel).Funnel(@object, this);
            return this;
        }

    }
}
