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
    public class ProducerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProducerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Upsert(int? id)
        {
            Producer producer = new Producer();
            if (id == null)
            {
                //this is for create
                return View(producer);
            }
            //this is for edit
            producer = _unitOfWork.Producer.Get(id.GetValueOrDefault());
            if (producer == null)
            {
                return NotFound();
            }
            return View(producer);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Producer producer)
        {
            if (ModelState.IsValid)
            {
                if (producer.Id == 0)
                {
                    _unitOfWork.Producer.Add(producer);
                }
                else
                {
                    _unitOfWork.Producer.Update(producer);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(producer);
        }
        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            var allObj = _unitOfWork.Producer.GetAll();
            return Json(new { data = allObj });
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Producer.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            _unitOfWork.Producer.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful" });
        }
        #endregion
    }
}