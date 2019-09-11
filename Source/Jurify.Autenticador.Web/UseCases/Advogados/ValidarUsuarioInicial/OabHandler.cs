using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jurify.Autenticador.Web.Infrastructure.Database.Context;

namespace Jurify.Autenticador.Web.UseCases.Advogados.ValidaUsuarioInicial
{
    public class OabHandler
    {
        private readonly AutenticadorContext _context;

        public OabHandler(AutenticadorContext context)
        {
            _context = context;
        }
        /* Resolver Lagomorpha 2.0 não é compatível com netcoreapp2.1
        [QueueHandler("validar-oab")]
        public void HandleNewOab(Oab oab)
        {

            _context.Oab.Add(oab);
            _context.SaveChanges();
            Debug.WriteLine(oab.NomeCompleto);
            Console.WriteLine("=================== MENSAGEM RECEBIDA =================");
        }
        */
    }
}
