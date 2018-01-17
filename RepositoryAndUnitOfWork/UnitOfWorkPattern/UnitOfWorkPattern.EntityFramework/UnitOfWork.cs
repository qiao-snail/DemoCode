using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWorkPattern.EntityFramework
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private RepositoryDemoEntities1 context = new RepositoryDemoEntities1();
        private EFBaseRepository<TPerson> _personRepository;

        public EFBaseRepository<TPerson> PersonRepository
        {
            get
            {
                return _personRepository ?? new EFBaseRepository<TPerson>(context);
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

}
