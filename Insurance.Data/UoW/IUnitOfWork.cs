using System;
using System.Data.Entity;

namespace Insurance.Data.UoW
{
    public interface IUnitOfWork: IDisposable
    {
        DbContext Context { get; }
        void Commit();
    }
}
