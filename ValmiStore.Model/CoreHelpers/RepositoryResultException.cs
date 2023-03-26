using System;

namespace Webmall.Model.CoreHelpers
{
    public class RepositoryResultException : Exception
    {
        public RepositoryResultException()
        {
        }

        //
        // Summary:
        //     Initializes a new instance of the System.Exception class with a specified error
        //     message.
        //
        // Parameters:
        //   message:
        //     The message that describes the error.
        public RepositoryResultException(string message) : base(message)
        {
        }

        //
        // Summary:
        //     Initializes a new instance of the System.Exception class with a specified error
        //     message and a reference to the inner exception that is the cause of this exception.
        //
        // Parameters:
        //   message:
        //     The error message that explains the reason for the exception.
        //
        //   innerException:
        //     The exception that is the cause of the current exception, or a null reference
        //     (Nothing in Visual Basic) if no inner exception is specified.
        public RepositoryResultException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public int ResultCode { get; set; }
        public string MethodName { get; set; }
        public string Parameters { get; set; }
        public string ErrorDetails { get; set; }
    }
}
