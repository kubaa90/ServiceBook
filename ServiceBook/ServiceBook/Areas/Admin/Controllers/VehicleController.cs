using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceBook.DataAccess.Repository.IRepository;
using ServiceBook.Models;

namespace ServiceBook.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class VehicleController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public VehicleController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Upsert(int? id)
        {
            Vehicle vehicle = new Vehicle();
            if (id == null)
            {
                //this is for create
                return View(vehicle);
            }
            //this is for edit
            vehicle = _unitOfWork.Vehicle.Get(id.GetValueOrDefault());
            if (vehicle == null)
            {
                return NotFound();
            }
            return View(vehicle);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                if (vehicle.Id == 0)
                {
                    _unitOfWork.Vehicle.Add(vehicle);
                }
                else
                {
                    _unitOfWork.Vehicle.Update(vehicle);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(vehicle);
        }
        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            var allObj = _unitOfWork.Vehicle.GetAll();
            return Json(new { data = allObj });
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Vehicle.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            _unitOfWork.Vehicle.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful" });
        }
        #endregion
    }
}