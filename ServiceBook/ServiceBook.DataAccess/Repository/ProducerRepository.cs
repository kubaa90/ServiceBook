using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceBook.DataAccess.Data;
using ServiceBook.DataAccess.Repository.IRepository;
using ServiceBook.Models;

namespace ServiceBook.DataAccess.Repository
{
    class ProducerRepository:Repository<Producer>, IProducerRepository
    {
        private readonly ApplicationDbContext _db;
        public ProducerRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Producer producer)
        {
            var objFromDb = _db.Producers.FirstOrDefault(s => s.Id == producer.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = producer.Name;
                objFromDb.Address = producer.Address;
                _db.SaveChanges();
            }
        }
    }
}
