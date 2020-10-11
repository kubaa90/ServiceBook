using System;
using System.Collections.Generic;
using System.Text;
using ServiceBook.DataAccess.Data;
using ServiceBook.DataAccess.Repository.IRepository;
using ServiceBook.Models;

namespace ServiceBook.DataAccess.Repository
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Vehicle = new VehicleRepository(_db);
            Producer = new ProducerRepository(_db);
            SpCall = new SP_Call(_db);
        }

        public IVehicleRepository Vehicle { get; private set; }
        public IProducerRepository Producer { get; private set; }
        public ISP_Call SpCall { get; private set; }
        public void Dispose()
        {
            _db.Dispose();
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
