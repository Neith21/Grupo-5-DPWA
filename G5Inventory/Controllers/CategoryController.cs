using FluentValidation;
using FluentValidation.Results;
using G5Inventory.Data;
using G5Inventory.Models;
using G5Inventory.Validations;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace G5Inventory.Controllers
{
    public class CategoryController : Controller
    {
        private IValidator<CategoryModel> _categoryValidator;

        public CategoryController(IValidator<CategoryModel> categoryValidator)
        {
            _categoryValidator = categoryValidator;
        }
        public IActionResult Index()
        {
            CategoryData categoryData = new CategoryData();

            return View(categoryData.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CategoryModel categoryModel)
        {

            ValidationResult validationResult = _categoryValidator.Validate(categoryModel);
            try
            {
                CategoryData categoryData = new CategoryData();
                categoryData.Add(categoryModel);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;

                validationResult.AddToModelState(this.ModelState);

                return View(categoryModel);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            CategoryData categoryData = new CategoryData();
            //var category = categoryData.GetAll().FirstOrDefault(category => category.IdCategory == id);
            var category = categoryData.GetById(id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CategoryModel categoryModel)
        {
            try
            {
                CategoryData categoryData = new CategoryData();
                categoryData.Edit(categoryModel);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;

                return View(categoryModel);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            CategoryData categoryData = new CategoryData();
            var category = categoryData.GetById(id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(CategoryModel categoryModel)
        {
            try
            {
                CategoryData categoryData = new CategoryData();
                categoryData.Delete(categoryModel);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;

                return View(categoryModel);
            }
        }
    }
}

