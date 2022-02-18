using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using UnitOfWorkConVariosRepositorios.Models;

namespace UnitOfWorkConVariosRepositorios.DA.Contexts
{
    public class AplicativoDbContext : DbContext, IAplicativoDbContext
    {
        public AplicativoDbContext(DbContextOptions<AplicativoDbContext> options) : base(options)
        {
        }

        public DbSet<Persona> Personas { get; set; }
        public DbSet<Auto> Autos { get; set; }


        public async Task<int> Commit()
        {
            try
            {
                return await this.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }           
        }

        public override void Dispose()
        {
            this.DisposeAsync();
        }
    }
}
