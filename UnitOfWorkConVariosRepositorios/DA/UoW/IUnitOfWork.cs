using System.Threading.Tasks;
using UnitOfWorkConVariosRepositorios.DA.Repositories;

namespace UnitOfWorkConVariosRepositorios.DA.UoW
{
    public interface IUnitOfWork
    {
        IAutosRepository Autosrepository { get; }
        IPersonasRepository Personasrepository { get; }
        void Dispose();
        Task<int> Commit();
    }
}
