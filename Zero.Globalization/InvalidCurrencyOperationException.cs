using System;
using System.Runtime.Serialization;

namespace Zero.Globalization
{
    /// <summary>
    /// The exception that is thrown when caused by an invalid currency operation.
    /// </summary>
    /// <seealso cref="CurrencyException" />
    [Serializable]
    public class InvalidCurrencyOperationException : CurrencyException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidCurrencyOperationException"/> class.
        /// </summary>
        public InvalidCurrencyOperationException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidCurrencyOperationException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public InvalidCurrencyOperationException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidCurrencyOperationException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (<see langword="Nothing" /> in Visual Basic) if no inner exception is specified.</param>
        public InvalidCurrencyOperationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidCurrencyOperationException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="StreamingContext" /> that contains contextual information about the source or destination.</param>
        protected InvalidCurrencyOperationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}