using Jurify.Autenticador.Web.Domain.Model.Entities;
using Jurify.Autenticador.Web.Domain.Model.Repositories;
using Jurify.Autenticador.Web.UseCases.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Jurify.Autenticador.Web.UseCases.Services.Concrete
{
    public class OfficeService : IOfficeService
    {
        private readonly IEscritorioRepositorio _repository;

        public OfficeService(IEscritorioRepositorio repository)
        {
            _repository = repository;
        }

        public async Task<Escritorio> FindByNameAsync(string officeName)
        {
            return await _repository.BuscarPorNomeAsync(officeName);
        }
    }
}
