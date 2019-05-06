using System;

namespace Jurify.Autenticador.Web.Domain.Model.Exceptions
{
    public class DomainValidationException : Exception
    {
        public string[] Errors { get; private set; }

        public DomainValidationException(string message) : base(message)
        {
            Errors = new[] { message };
        }

        public DomainValidationException(string[] messages) : base(string.Join(", ", messages))
        {
            Errors = messages;
        }
    }
}
