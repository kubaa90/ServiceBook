using System;
using System.Collections.Generic;
using System.Text;
using ServiceBook.Models;

namespace ServiceBook.DataAccess.Repository.IRepository
{
    public interface IVehicleRepository:IRepository<Vehicle>
    {
        void Update(Vehicle vehicle);
    }
}
