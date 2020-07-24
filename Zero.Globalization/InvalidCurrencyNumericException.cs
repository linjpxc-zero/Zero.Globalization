using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Zero.Globalization
{
    /// <summary>
    /// The exception that is thrown when caused by an invalid currency numeric.
    /// </summary>
    /// <seealso cref="Zero.Globalization.CurrencyException" />
    [Serializable]
    [SuppressMessage("Design", "CA1032:实现标准异常构造函数", Justification = "<挂起>")]
    public class InvalidCurrencyNumericException : CurrencyException
    {
        public InvalidCurrencyNumericException(string invalidNumeric)
            : base($"The [{invalidNumeric}] is an invalid currency numeric.")
        {
            this.InvalidNumeric = invalidNumeric;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidCurrencyNumericException"/> class.
        /// </summary>
        /// <param name="invalidNumeric">The invalid currency numeric.</param>
        /// <param name="innerException">The exception that is the cause of the current exception. If the <paramref name="innerException" /> parameter is not a null reference, the current exception is raised in a <see langword="catch" /> block that handles the inner exception.</param>
        public InvalidCurrencyNumericException(string invalidNumeric, Exception innerException)
            : base($"The [{invalidNumeric}] is an invalid currency numeric.", innerException)
        {
            this.InvalidNumeric = invalidNumeric;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidCurrencyNumericException"/> class.
        /// </summary>
        /// <param name="invalidNumeric">The invalid currency numeric.</param>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public InvalidCurrencyNumericException(string invalidNumeric, string message)
            : base(message)
        {
            this.InvalidNumeric = invalidNumeric;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidCurrencyNumericException"/> class.
        /// </summary>
        /// <param name="invalidNumeric">The invalid currency numeric.</param>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception. If the <paramref name="innerException" /> parameter is not a null reference, the current exception is raised in a <see langword="catch" /> block that handles the inner exception.</param>
        public InvalidCurrencyNumericException(string invalidNumeric, string message, Exception innerException)
            : base(message, innerException)
        {
            this.InvalidNumeric = invalidNumeric;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidCurrencyNumericException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="StreamingContext" /> that contains contextual information about the source or destination.</param>
        protected InvalidCurrencyNumericException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        /// Gets the invalid numeric.
        /// </summary>
        /// <value>
        /// The invalid numeric.
        /// </value>
        public string InvalidNumeric { get; }
    }
}