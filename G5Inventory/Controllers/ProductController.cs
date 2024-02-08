using FluentValidation;
using FluentValidation.Results;
using G5Inventory.Data;
using G5Inventory.Models;
using G5Inventory.Validations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace G5Inventory.Controllers
{
    public class ProductController : Controller
    {
		private IValidator<ProductModel> _productValidator;

		ProductData productData = new ProductData();

		public ProductController(IValidator<ProductModel> productValidator)
		{
			_productValidator = productValidator;
		}

		public IActionResult Index()
        {
            return View(productData.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductModel productModel)
        {
			ValidationResult validationResult = _productValidator.Validate(productModel);

            try
            {
                productData.Add(productModel);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;

				validationResult.AddToModelState(this.ModelState);

                return View(productModel);
            }
        }

		[HttpGet]
		public IActionResult Edit(int id)
		{
			var product = productData.GetAll().FirstOrDefault(product => product.IdProduct == id);

			if (product == null)
			{
				return NotFound();
			}

			return View(product);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(ProductModel productModel)
		{
			try
			{
				productData.Edit(productModel);

				return RedirectToAction(nameof(Index));
			}
			catch (Exception ex)
			{
				ViewBag.Error = ex.Message;

				return View(productModel);
			}
		}

		[HttpGet]
		public IActionResult Delete(int id)
		{
			var product = productData.GetAll().FirstOrDefault(product => product.IdProduct == id);

			if (product == null)
			{
				return NotFound();
			}

			return View(product);
		}

		[HttpPost]
		public IActionResult Delete(ProductModel productModel)
		{
			try
			{
				productData.Delete(productModel.IdProduct);

				return RedirectToAction(nameof(Index));
			}
			catch (Exception ex)
			{
				ViewBag.Error = ex.Message;

				return View(productModel);
			}
		}
	}
}
