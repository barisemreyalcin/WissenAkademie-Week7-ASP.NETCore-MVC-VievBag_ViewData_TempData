using Microsoft.AspNetCore.Mvc;

namespace PassDataViewAndControls.Controllers
{
	public class SampleController : Controller
	{
		public IActionResult Index()
		{
			// Controller'dan View'a Data Taşıma
			// Yöntem 1: ViewBag (Dynamic)
			ViewBag.GetDate = DateTime.Now.ToLongDateString(); // GetDate benim oluşturduğum bir değişken
			ViewBag.Names = new string[] {"John", "Jane", "Mark", "Philipp"}; // Object taşıabiliyor

			// Yöntem 2: ViewData (Key - Value olarak çalışır, object taşıyabilir)
			ViewData["Hour"] = DateTime.Now.ToLongDateString();

			// Yöntem 3: TempData (Key - Value olarak çalışır)
			TempData["Day"] = DateTime.Now.Day;

			return RedirectToAction("Index2");
			//return View();
		}

		public IActionResult Index2()
		{
			return View();
		}
	}
}
