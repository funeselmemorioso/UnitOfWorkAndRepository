using System.Collections.Generic;
using System.Threading.Tasks;
using UnitOfWorkConVariosRepositorios.Models;

namespace UnitOfWorkConVariosRepositorios.DA.Repositories
{
    public interface IPersonasRepository
    {
        Task<Persona> Insert(Persona persona);
        Task<List<Persona>> GetAll();
        Task<Persona> Update(Persona persona);
    }
}
