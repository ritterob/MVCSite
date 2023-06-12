using Microsoft.AspNetCore.Mvc;
using MVCSite.Models;
using MimeKit;
using MailKit.Net.Smtp;

namespace MVCSite.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _config;

        public HomeController(ILogger<HomeController> logger, IConfiguration config) {
            _logger = logger;
            _config = config;
        }

        public IActionResult Index() {
            return View();
        }

        public IActionResult Resume() {
            return View();
        }

        public IActionResult Projects() {
            return View();
        }

        public IActionResult Connections() {
            return View();
        }

        public IActionResult Contact() {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactViewModel cvm) {

            if (!ModelState.IsValid) { return View(cvm); }

            string message = string.Format("You recieved a message from {0} ({1}) about {2}.<br/>" +
                "Message:<br/>{3}", cvm.Name, cvm.Email, cvm.Subject, cvm.Message);

            var mm = new MimeMessage();
            mm.From.Add(new MailboxAddress("Sender", _config.GetValue<string>("Credentials:Email:User")));
            mm.To.Add(new MailboxAddress("Personal", _config.GetValue<string>("Credentials:Email:Recipient")));
            mm.Subject = cvm.Subject;
            mm.Body = new TextPart("HTML") { Text = message };
            mm.Priority = MessagePriority.Urgent;
            mm.ReplyTo.Add(new MailboxAddress("User", cvm.Email));

            using (var client = new SmtpClient()) {

                client.Connect(_config.GetValue<string>("Credentials:Email:Client"));
                client.Authenticate(_config.GetValue<string>("Credentials:Email:User"),
                    _config.GetValue<string>("Credentials:Email:Password"));
                try {
                    client.Send(mm);
                }
                catch (Exception e) {

                   ViewBag.Error = string.Format("There was an error sending your message. Please try " +
                       "again later.<br/>Error message: {0}", e.StackTrace);
                    return View(cvm);
                }

            }   // end using directive

            return View("EmailConfirmation", cvm);

        }   // end IActionResult Contact(ContactViewModel)

    }   // end class HomeController

}