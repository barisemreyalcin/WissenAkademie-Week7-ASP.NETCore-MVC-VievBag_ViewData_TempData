using Microsoft.AspNetCore.Mvc;

namespace PassDataViewAndControls.Controllers
{
	public class OrderController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult SellProduct()
		{
			return View();
		}

		//[HttpPost]
		//public IActionResult SellProduct(string ProductID, string ProductName, string ProductPrice)
		//{
		//	TempData["ProductID"] = int.Parse(ProductID);
		//	TempData["ProductName"] = ProductName;
		//	TempData["ProductPrice"] = ProductPrice;
		//	return RedirectToAction("OrderInfo", "Stock"); // Action, Controller
		//}


		// Eskiye uyumluluk için
		[HttpPost]
		public IActionResult SellProduct(IFormCollection form) // html'deki formu temsil eder
		{
			TempData["ProductID"] = int.Parse(form["ProductID"].ToString());
			TempData["ProductName"] = form["ProductName"].ToString();
			TempData["ProductPrice"] = form["ProductPrice"].ToString(); // [input name attr]
			return RedirectToAction("OrderInfo", "Stock"); // Action, Controller
		}
	}
}
