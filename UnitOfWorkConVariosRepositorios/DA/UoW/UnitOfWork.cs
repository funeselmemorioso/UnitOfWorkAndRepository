using System;
using System.Threading.Tasks;
using UnitOfWorkConVariosRepositorios.DA.Contexts;
using UnitOfWorkConVariosRepositorios.DA.Repositories;

namespace UnitOfWorkConVariosRepositorios.DA.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool disposed = false;

        private IAplicativoDbContext _aplicativoDbContext;
        public IAutosRepository Autosrepository { get; }
        public IPersonasRepository Personasrepository { get; }       

        public UnitOfWork(IAplicativoDbContext aplicativoDbContext)
        {
            _aplicativoDbContext = aplicativoDbContext;
            Autosrepository = new AutosRepository(_aplicativoDbContext);     
            Personasrepository = new PersonasRepository(_aplicativoDbContext);            
        }

        public async Task<int> Commit()
        {
            try
            {
                return await _aplicativoDbContext.Commit();
            }
            catch (Exception e)
            {
                throw e;
            }           
        }        

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _aplicativoDbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);            
        }



    }
}
