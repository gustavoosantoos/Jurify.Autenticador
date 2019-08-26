using Jurify.Autenticador.Web.Domain.Model.Entities;
using Jurify.Autenticador.Web.Domain.Model.Repositories;
using Jurify.Autenticador.Web.UseCases.Services.Abstractions;
using System.Threading.Tasks;

namespace Jurify.Autenticador.Web.UseCases.Services.Concrete
{
    public class EscritorioServico : IEscritorioServico
    {
        private readonly IEscritorioRepositorio _repository;

        public EscritorioServico(IEscritorioRepositorio repository)
        {
            _repository = repository;
        }

        public async Task<Escritorio> BuscarPorNomeAsync(string nomeFantasia)
        {
            return await _repository.BuscarPorNomeAsync(nomeFantasia);
        }
    }
}
