using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Jurify.Autenticador.Web.UseCases.Core
{
    public class Response
    {
        private readonly List<string> _messages = new List<string>();

        public IEnumerable<string> Errors { get; }
        public object Result { get; }
        public bool IsSucess => !Errors.Any();
        public bool IsFailure => !IsSucess;
        
        private Response() => Errors = new ReadOnlyCollection<string>(_messages);

        private Response(object result) : this() => Result = result;

        public Response AddErrors(IEnumerable<string> messages)
        {
            _messages.AddRange(messages);
            return this;
        }

        public Response AddError(string message)
        {
            _messages.Add(message);
            return this;
        }

        public static Response WithResult(object result)
        {
            return new Response(result);
        }

        public static Response WithErrors(params string[] messages)
        {
            var response = new Response();
            response.AddErrors(messages);
            return response;
        }
    }
}
