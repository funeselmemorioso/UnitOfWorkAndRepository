using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWorkConVariosRepositorios.DA.Contexts;
using UnitOfWorkConVariosRepositorios.Models;

namespace UnitOfWorkConVariosRepositorios.DA.Repositories
{
    public class PersonasRepository : IPersonasRepository
    {
        private IAplicativoDbContext _aplicativoDbContext;

        public PersonasRepository(IAplicativoDbContext aplicativoDbContext)
        {
            _aplicativoDbContext = aplicativoDbContext;
        }

        public async Task<List<Persona>> GetAll()
        {
            return await _aplicativoDbContext.Personas.ToListAsync();
        }

        public async Task<Persona> Insert(Persona persona)
        {
            try
            {
                await _aplicativoDbContext.Personas.AddAsync(persona);
                return persona;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Persona> Update(Persona persona)
        {
            try
            {
                Persona p = await _aplicativoDbContext.Personas.Where(x => x.Id == persona.Id).FirstAsync();
                
                if(p != null)
                {
                    p.Telefono = persona.Telefono;
                    p.Nombre = persona.Nombre;
                }               
                
                return p;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
