using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using DataAccess.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Data;
using FluentValidation.Results;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace AdminPanel.Controllers
{
    public class CarController : Controller
    {
        ICarService carService;

        public CarController(ICarService carService)
        {
            this.carService = carService;
        }

        Context con = new Context();


        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult Index()
        {
            var result = carService.ListAllCar();
            return View(result);
        }

        [HttpGet]
        public IActionResult AddCar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCar(Car c)
        {
            CarValidator carValidator = new CarValidator();
            ValidationResult results = carValidator.Validate(c);
            if (results.IsValid)
            {
                carService.AddCar(c);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult UpdateCar(int id)
        {
            var result = carService.GetById(id);
            return View(result);
        }
        [HttpPost]
        public IActionResult UpdateCar(Car c)
        {
            CarValidator carValidator = new CarValidator();
            ValidationResult results = carValidator.Validate(c);
            if (results.IsValid)
            {
                carService.UpdateCar(c);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var result = carService.GetById(id);
            carService.DeleteCar(result);
            return RedirectToAction("Index");
        }

    }
}
