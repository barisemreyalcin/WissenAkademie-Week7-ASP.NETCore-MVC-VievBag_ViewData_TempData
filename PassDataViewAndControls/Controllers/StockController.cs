using Microsoft.AspNetCore.Mvc;

namespace PassDataViewAndControls.Controllers
{
	public class StockController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult OrderInfo()
		{
			int ProductID = int.Parse(TempData["ProductID"].ToString());
			string ProductName = TempData["ProductName"].ToString();
			string ProductPrice = TempData["ProductPrice"].ToString();

			// Modelim yok. ViewBag ile View'e yolluyorum

			ViewBag.ProductID = ProductID;
			ViewBag.ProductName = ProductName;
			ViewBag.ProductPrice = ProductPrice;

			return View();
		}
	}
}
