using Jurify.Autenticador.Web.Domain.Model.Entities;
using Jurify.Autenticador.Web.Domain.Model.Services.Abstractions;
using Jurify.Autenticador.Web.Domain.Model.ValueObjects;
using Jurify.Autenticador.Web.Infrastructure.Database.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Jurify.Autenticador.Web.UseCases.Services.Concrete
{
    public class SeedDatabase
    {
        private readonly AutenticadorContext _context;
        private readonly IHashService _hashService;

        public SeedDatabase(AutenticadorContext context, IHashService hashService)
        {
            _context = context;
            _hashService = hashService;
        }

        public void Seed()
        {
            //TODO: Remove this class, only for development purposes
            try
            {
                if (_context.OfficeUsers.Count() != 0)
                    return;
                
                var office1 = new Office(
                    new OfficeInfo("Escritório de teste 1")
                );

                var office2 = new Office(
                    new OfficeInfo("Escritório de teste 2")
                );

                var user1 = new OfficeUser(
                    office1.Id,
                    "gustavo",
                    _hashService.Hash("gustavo"),
                    new PersonalInfo("Gustavo", "Santos"),
                    new List<Claim>()
                );

                var user2 = new OfficeUser(
                    office1.Id,
                    "rosana",
                    _hashService.Hash("rosana"),
                    new PersonalInfo("Rosana", "Santos"),
                    new List<Claim>()
                );

                var user3 = new OfficeUser(
                    office2.Id,
                    "gabriel",
                    _hashService.Hash("gabriel"),
                    new PersonalInfo("Gabriel", "Gorbato"),
                    new List<Claim>()
                );

                _context.Offices.Add(office1);
                _context.Offices.Add(office2);
                _context.OfficeUsers.Add(user1);
                _context.OfficeUsers.Add(user2);
                _context.OfficeUsers.Add(user3);

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
