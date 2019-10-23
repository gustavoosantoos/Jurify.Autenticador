using Jurify.Autenticador.Web.Infrastructure.Database.Context;
using Jurify.Autenticador.Web.UseCases.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Jurify.Autenticador.Web.UseCases.Clientes.ListarEscritorios
{
    public class ListarEscritoriosQueryHandler : IRequestHandler<ListarEscritoriosQuery, Response<Escritorio[]>>
    {
        private readonly AutenticadorContext _context;

        public ListarEscritoriosQueryHandler(AutenticadorContext context)
        {
            _context = context;
        }

        public async Task<Response<Escritorio[]>> Handle(ListarEscritoriosQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var escritorios = await _context
                    .Escritorios
                    .Include(e => e.Endereco)
                    .Include(e => e.Especialidades)
                        .ThenInclude(es => es.Especialidade)
                    .Where(e => e.Endereco != null &&
                                e.Endereco.Latitude.HasValue &&
                                e.Endereco.Longitude.HasValue &&
                                !e.Apagado)
                    .Select(e => new Escritorio
                    {
                        Codigo = e.Codigo,
                        RazaoSocial = e.Informacoes.RazaoSocial,
                        Latitude = e.Endereco.Latitude,
                        Longitude = e.Endereco.Longitude,
                        Endereco = $"{e.Endereco.Rua}, {e.Endereco.Numero} - {e.Endereco.Cidade}/{e.Endereco.Estado}",
                        Especialidades = e.Especialidades.Select(es => new Especialidade
                        {
                            Codigo = es.Especialidade.Codigo,
                            Nome = es.Especialidade.Nome,
                            Descricao = es.Especialidade.Descricao
                        })
                    })
                    .ToListAsync();

                return Response<Escritorio[]>.WithResult(escritorios.ToArray());
            }
            catch (Exception ex)
            {
                return Response<Escritorio[]>.WithResult(null);
            }
        }
    }
}
