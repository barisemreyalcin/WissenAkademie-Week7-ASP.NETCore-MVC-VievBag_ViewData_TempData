using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;

namespace PassDataViewAndControls.Controllers
{
	public class MailController : Controller
	{
		private readonly ILogger<MailController> logger;
		public MailController(ILogger<MailController> _logger)
		{
			this.logger = _logger;
		}

		public IActionResult Index()
		{
			logger.LogInformation("Contact form loading...", typeof(MailController));

			return View();
		}

		[HttpPost]
		public IActionResult Index(string txtEmail, string txtSubject, string txtMessage)
		{
			string msg = string.Empty;

			try
			{
				MailMessage message = new MailMessage();
				SmtpClient smtp = new SmtpClient();

				message.From = new MailAddress("info@contoso.com", "Contoso Inc"); // mail nereden gidecek, gönderen başlığı ne olacak
																				   // Birden fazla adres eklenebilir
				message.To.Add(txtEmail);
				message.Subject = txtSubject;
				message.IsBodyHtml = true;
				message.Body = txtMessage;
				// maili göndermek için bir porttan çıkış yapılacak
				smtp.Port = 587;
				smtp.Host = "smtp.gmail.com";
				smtp.EnableSsl = true;
				smtp.UseDefaultCredentials = false;
				smtp.Credentials = new NetworkCredential("user", "password"); // from'daki user name ve password
				smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
				smtp.Send(message);

				msg = "Your message has been sent successfully";

				ViewBag.Result = msg;
				logger.LogInformation(msg); // EV'de logluyoruz
			}
			catch (Exception ex)
			{
				msg = "Error: " + ex.Message;
				ViewBag.Result = msg;
				logger.LogWarning(msg);
			}

			return View();
		}
	}
}
