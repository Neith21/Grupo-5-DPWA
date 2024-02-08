using FluentValidation;
using FluentValidation.Results;
using G5Inventory.Data;
using G5Inventory.Models;
using G5Inventory.Validations;
using Microsoft.AspNetCore.Mvc;

namespace G5Inventory.Controllers
{
    public class ProviderController : Controller
    {
        private IValidator<ProviderModel> _providerValidator;

        public ProviderController(IValidator<ProviderModel> providerValidator)
        {
            _providerValidator = providerValidator;
        }

        public IActionResult Index()
        {
            ProviderData providerData = new ProviderData();
            return View(providerData.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProviderModel providerModel)
        {
            ValidationResult validationResult = _providerValidator.Validate(providerModel);

            try
            {
                ProviderData providerData = new ProviderData();
                providerData.Add(providerModel);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;

                validationResult.AddToModelState(this.ModelState);

                return View(providerModel);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ProviderData providerData = new ProviderData();
            var provider = providerData.GetById(id);

            if (provider == null)
            {
                return NotFound();
            }

            return View(provider);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProviderModel providerModel)
        {
            try
            {
                ProviderData providerData = new ProviderData();
                providerData.Edit(providerModel);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;

                return View(providerModel);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            ProviderData providerData = new ProviderData();

            var provider = providerData.GetById(id);

            if (provider == null)
            {
                return NotFound();
            }

            return View(provider);
        }

        [HttpPost]
        public IActionResult Delete(ProviderModel providerModel)
        {
            try
            {
                ProviderData providerData = new ProviderData();
                providerData.Delete(providerModel.IdProvider);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;

                return View(providerModel);
            }
        }
    }
}
