using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceBook.DataAccess.Data;
using ServiceBook.DataAccess.Repository.IRepository;
using ServiceBook.Models;

namespace ServiceBook.DataAccess.Repository
{
    public class FaultRepository : Repository<Fault>, IFaultRepository
    {
        private readonly ApplicationDbContext _db;

        public FaultRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Fault fault)
        {
            var objFromDb = _db.Faults.FirstOrDefault(s => s.Id == fault.Id);
            if (objFromDb != null)
            {
                objFromDb.Description = fault.Description;
                objFromDb.VehicleId = fault.VehicleId;
            }
        }
    }
}
