using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeowieAPI.Application.Exceptions
{
    public class CreateUserFailedException : Exception
    {
        public CreateUserFailedException() : base("Create user failed!")
        {
        }

        public CreateUserFailedException(string? message) : base(message)
        {
        }

        public CreateUserFailedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
