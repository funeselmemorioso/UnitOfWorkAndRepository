using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using UnitOfWorkConVariosRepositorios.Models;

namespace UnitOfWorkConVariosRepositorios.DA.Contexts
{
    public interface IAplicativoDbContext
    {
        DbSet<Persona> Personas { get; set; }
        DbSet<Auto> Autos { get; set; }

        Task<int> Commit();
        void Dispose();
    }
}
