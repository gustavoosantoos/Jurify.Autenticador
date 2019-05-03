using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Jurify.Autenticador.Web.UseCases.Core
{
    public class Response<T>
    {
        private readonly List<string> _messages = new List<string>();

        public IEnumerable<string> Errors { get; }
        public T Result { get; }
        public bool IsSucess => !Errors.Any();
        public bool IsFailure => !IsSucess;
        
        private Response() => Errors = new ReadOnlyCollection<string>(_messages);

        private Response(T result) : this() => Result = result;

        public Response<T> AddErrors(IEnumerable<string> messages)
        {
            _messages.AddRange(messages);
            return this;
        }

        public Response<T> AddError(string message)
        {
            _messages.Add(message);
            return this;
        }

        public static Response<T> WithResult(T result)
        {
            return new Response<T>(result);
        }

        public static Response<T> WithErrors(params string[] messages)
        {
            var response = new Response<T>();
            response.AddErrors(messages);
            return response;
        }
    }
}
