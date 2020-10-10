using System;
using System.Collections.Generic;
using System.Text;
using ServiceBook.Models;

namespace ServiceBook.DataAccess.Repository.IRepository
{
    public interface IProducerRepository:IRepository<Producer>
    {
        void Update(Producer producer);
    }
}
