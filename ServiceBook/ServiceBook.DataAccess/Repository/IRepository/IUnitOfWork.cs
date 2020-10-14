using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceBook.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        public IVehicleRepository Vehicle { get; }
        public IProducerRepository Producer { get; }
        public IFaultRepository Fault { get; }
        public ISP_Call SpCall { get; }
        void Save();
    }
}
