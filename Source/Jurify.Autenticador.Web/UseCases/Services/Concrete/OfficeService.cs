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
        private readonly IOfficeRepository _repository;

        public OfficeService(IOfficeRepository repository)
        {
            _repository = repository;
        }

        public async Task<Office> FindByNameAsync(string officeName)
        {
            return await _repository.FindByNameAsync(officeName);
        }
    }
}
