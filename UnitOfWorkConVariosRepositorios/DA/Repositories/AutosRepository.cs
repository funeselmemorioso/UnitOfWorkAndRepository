using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWorkConVariosRepositorios.DA.Contexts;
using UnitOfWorkConVariosRepositorios.Models;

namespace UnitOfWorkConVariosRepositorios.DA.Repositories
{
    public class AutosRepository : IAutosRepository
    {
        private IAplicativoDbContext _aplicativoDbContext;

        public AutosRepository(IAplicativoDbContext aplicativoDbContext)
        {
            _aplicativoDbContext = aplicativoDbContext;
        }

        public async Task<List<Auto>> GetAll()
        {
            return await _aplicativoDbContext.Autos.ToListAsync();
        }

        public async Task<Auto> Insert(Auto auto)
        {
            try
            {
                await _aplicativoDbContext.Autos.AddAsync(auto);
                return auto;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Auto> Update(Auto auto)
        {
            try
            {
                Auto a = await _aplicativoDbContext.Autos.Where(x => x.Id == auto.Id).FirstAsync();

                if (a != null)
                {
                    a.Marca = auto.Marca;
                    a.Modelo = auto.Modelo;
                }

                return a;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
