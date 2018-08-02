using System;
using System.Data.Entity;

namespace Insurance.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {

        public DbContext Context { get; }

        public UnitOfWork(DbContext context)
        {
            Context = context;
        }
        public void Commit()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();

        }
    }
}
