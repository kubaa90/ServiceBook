using System;
using System.Collections.Generic;
using System.Text;
using ServiceBook.Models;

namespace ServiceBook.DataAccess.Repository.IRepository
{
    public interface IFaultRepository : IRepository<Fault>
    {
        void Update(Fault producer);
    }
}
