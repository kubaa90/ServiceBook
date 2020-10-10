using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceBook.DataAccess.Data;
using ServiceBook.DataAccess.Repository.IRepository;
using ServiceBook.Models;

namespace ServiceBook.DataAccess.Repository
{
    public class VehicleRepository:Repository<Vehicle>,IVehicleRepository
    {
        private readonly ApplicationDbContext _db;

        public VehicleRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Vehicle vehicle)
        {
            var objFromDb = _db.Vehicles.FirstOrDefault(s => s.Id == vehicle.Id);
            if (objFromDb != null)
            {
                objFromDb.Number = vehicle.Number;
                objFromDb.PlateNumber = vehicle.PlateNumber;
                objFromDb.RegistrationDate = vehicle.RegistrationDate;
                objFromDb.VIN = vehicle.VIN;
                _db.SaveChanges();
            }
        }
    }
}
