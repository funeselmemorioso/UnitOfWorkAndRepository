using System.Collections.Generic;
using System.Threading.Tasks;
using UnitOfWorkConVariosRepositorios.Models;

namespace UnitOfWorkConVariosRepositorios.DA.Repositories
{
    public interface IAutosRepository
    {
        Task<List<Auto>> GetAll();
        Task<Auto> Insert(Auto auto);
        Task<Auto> Update(Auto auto);
    }
}
