using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Zero.Globalization
{
    /// <summary>
    /// The exception that is thrown when caused by an invalid currency code.
    /// </summary>
    /// <seealso cref="CurrencyException" />
    [Serializable]
    [SuppressMessage("Design", "CA1032:实现标准异常构造函数", Justification = "<挂起>")]
    public class InvalidCurrencyCodeException : CurrencyException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidCurrencyCodeException"/> class.
        /// </summary>
        /// <param name="invalidCode">The invalid currency code.</param>
        public InvalidCurrencyCodeException(string invalidCode)
            : base($"The [{invalidCode}] is an invalid currency code.")
        {
            this.InvalidCode = invalidCode;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidCurrencyCodeException"/> class.
        /// </summary>
        /// <param name="invalidCode">The invalid currency code.</param>
        /// <param name="innerException">The exception that is the cause of the current exception. If the <paramref name="innerException" /> parameter is not a null reference, the current exception is raised in a <see langword="catch" /> block that handles the inner exception.</param>
        public InvalidCurrencyCodeException(string invalidCode, Exception innerException)
            : base($"The [{invalidCode}] is an invalid currency code.", innerException)
        {
            this.InvalidCode = invalidCode;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidCurrencyCodeException"/> class.
        /// </summary>
        /// <param name="invalidCode">The invalid currency code.</param>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public InvalidCurrencyCodeException(string invalidCode, string message)
            : base(message)
        {
            this.InvalidCode = invalidCode;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidCurrencyCodeException"/> class.
        /// </summary>
        /// <param name="invalidCode">The invalid currency code.</param>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception. If the <paramref name="innerException" /> parameter is not a null reference, the current exception is raised in a <see langword="catch" /> block that handles the inner exception.</param>
        public InvalidCurrencyCodeException(string invalidCode, string message, Exception innerException)
            : base(message, innerException)
        {
            this.InvalidCode = invalidCode;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidCurrencyCodeException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="StreamingContext" /> that contains contextual information about the source or destination.</param>
        protected InvalidCurrencyCodeException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        /// The currency code that caused the error
        /// </summary>
        /// <value>
        /// The invalid code.
        /// </value>
        public string InvalidCode { get; }
    }
}