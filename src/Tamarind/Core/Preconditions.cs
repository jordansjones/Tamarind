using System;
using System.Diagnostics;
using System.Linq;

using Tamarind.Annotations;

namespace Tamarind.Core
{
    /// <summary>
    ///     Simple static methods to be called at the start of your own methods to verify correct arugments and state.
    ///     <para>
    ///         This allows constructs such as:
    ///         <code>
    ///   if (count &lt;= 0)
    ///   {
    ///  		throw new ArgumentException("must be positive: " + count);
    ///   }
    ///   </code>
    ///         to be replaced with the more compact
    ///         <c>Preconditions.CheckArgument(count &gt; 0, "count", "must be positive: {0}", count)</c>.
    ///     </para>
    ///     <para>
    ///         Note that the sense of the expression is inverted; with <see cref="Preconditions" /> you declare what you
    ///         expect to be <em>true</em>.
    ///     </para>
    /// </summary>
    public static class Preconditions
    {

        /// <summary>
        ///     Ensures the truth of an expression involving one or more parameters to the calling method.
        /// </summary>
        [DebuggerStepThrough]
        public static void CheckArgument(bool expression)
        {
            if (!expression)
            {
                throw new ArgumentException();
            }
        }

        /// <summary>
        ///     Ensures the truth of an expression involving one or more parameters to the calling method.
        /// </summary>
        [DebuggerStepThrough]
        public static void CheckArgument(bool expression, string argumentName)
        {
            if (!expression)
            {
                throw new ArgumentException(argumentName);
            }
        }

        /// <summary>
        ///     Ensures the truth of an expression involving one or more parameters to the calling method.
        /// </summary>
        [DebuggerStepThrough]
        [StringFormatMethod("message")]
        public static void CheckArgument(bool expression, string argumentName, string message, params object[] args)
        {
            if (!expression)
            {
                throw new ArgumentException(string.Format(message, args), argumentName);
            }
        }

        /// <summary>
        ///     Ensures that an object reference passed as a parameter to the calling method is not null.
        /// </summary>
        [DebuggerStepThrough]
        public static T CheckNotNull<T>(T reference)
            where T : class
        {
            if (reference == null)
            {
                throw new ArgumentNullException();
            }
            return reference;
        }

        /// <summary>
        ///     Ensures that an object reference passed as a parameter to the calling method is not null.
        /// </summary>
        [DebuggerStepThrough]
        public static T CheckNotNull<T>(T reference, string argumentName)
            where T : class
        {
            if (reference == null)
            {
                throw new ArgumentNullException(argumentName);
            }
            return reference;
        }

        /// <summary>
        ///     Ensures that an object reference passed as a parameter to the calling method is not null.
        /// </summary>
        [DebuggerStepThrough]
        [StringFormatMethod("message")]
        public static T CheckNotNull<T>(T reference, string argumentName, string message, params object[] args)
            where T : class
        {
            if (reference == null)
            {
                throw new ArgumentNullException(argumentName, string.Format(message, args));
            }
            return reference;
        }

        /// <summary>
        /// Ensures that <paramref name="start"/> and <paramref name="end"/> specify a valid
        /// <em>positions</em> in an enumerable of <paramref name="size"/>, and are in order.
        /// A position index may range from zero to <paramref name="size"/>, inclusive.
        /// </summary>
        /// <param name="start">A user-supplied index identifying a starting position in an enumerable.</param>
        /// <param name="end">A user-supplied index identifying an ending position in an enumerable.</param>
        /// <param name="size">The size of the enumerable.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// If either index is negative or is greater than <paramref name="size"/>,
        /// or if <paramref name="end"/> is less than <paramref name="start"/>
        /// </exception>
        /// <exception cref="ArgumentException">If <paramref name="size"/> is negative.</exception>
        [DebuggerStepThrough]
        public static void CheckPositionIndexes(int start, int end, int size)
        {
            if (start < 0 || end < start || end > size)
            {
                if (size < 0) throw new ArgumentException("Negative size: " + size, "size");
                if (end < 0) throw new ArgumentOutOfRangeException("end", end, "end index must not be negative");
                if (start > size) throw new ArgumentOutOfRangeException("start", start, string.Format("start index must not be greater than size {0}", size));
                if (end > size) throw new ArgumentOutOfRangeException("end", end, string.Format("end index must not be greater than size {0}", size));
                
                throw new ArgumentOutOfRangeException("end", end, string.Format("end index must not be less that start index ({0})", start));
            }
        }

        /// <summary>
        ///     Ensures the truth of an expression involving the state of the calling instance, but not involving any parameters to
        ///     the calling method.
        /// </summary>
        [DebuggerStepThrough]
        public static void CheckState(bool expression)
        {
            if (!expression)
            {
                throw new InvalidOperationException();
            }
        }

        /// <summary>
        ///     Ensures the truth of an expression involving the state of the calling instance, but not involving any parameters to
        ///     the calling method.
        /// </summary>
        [DebuggerStepThrough]
        [StringFormatMethod("message")]
        public static void CheckState(bool expression, string message, params object[] args)
        {
            if (!expression)
            {
                throw new InvalidOperationException(string.Format(message, args));
            }
        }

    }
}
