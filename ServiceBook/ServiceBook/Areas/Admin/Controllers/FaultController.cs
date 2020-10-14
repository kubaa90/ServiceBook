using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ServiceBook.DataAccess.Repository.IRepository;
using ServiceBook.Models;
using ServiceBook.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceBook.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FaultController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public FaultController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Upsert(int? id)
        {
            FaultViewModel faultVM = new FaultViewModel()
            {
                Fault = new Fault(),
                VehicleList = _unitOfWork.Vehicle.GetAll().Select(i=>new SelectListItem{
                    Text = i.Number,
                    Value = i.Id.ToString()
                })};
            if (id == null)
            {
                //this is for create
                return View(faultVM);
            }
            //this is for edit
            faultVM.Fault = _unitOfWork.Fault.Get(id.GetValueOrDefault());
            if (faultVM.Fault == null)
            {
                return NotFound();
            }
            return View(faultVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(FaultViewModel faultVM)
        {
            if (ModelState.IsValid)
            {
                if (faultVM.Fault.Id == 0)
                {
                    _unitOfWork.Fault.Add(faultVM.Fault);

                }
                else
                {
                    _unitOfWork.Fault.Update(faultVM.Fault);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                faultVM.VehicleList = _unitOfWork.Vehicle.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Number,
                    Value = i.Id.ToString()
                });
                if (faultVM.Fault.Id != 0)
                {
                    faultVM.Fault = _unitOfWork.Fault.Get(faultVM.Fault.Id);
                }
            }
            return View(faultVM);
        }
        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            var allObj = _unitOfWork.Fault.GetAll(includeProperties:"Vehicle");
            return Json(new { data = allObj });
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Fault.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            _unitOfWork.Fault.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful" });
        }
        #endregion
    }
}