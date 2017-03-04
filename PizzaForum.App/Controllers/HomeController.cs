namespace PizzaForum.App.Controllers
{
    using System.Collections.Generic;
    using PizzaForum.App.Security;
    using PizzaForum.App.Services;
    using PizzaForum.App.ViewModels;
    using SimpleHttpServer.Models;
    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces.Generic;

    public class HomeController : Controller
    {
        private HomeService service;

        public HomeController()
        {
            this.service = new HomeService();
        }

        [HttpGet]
        public IActionResult<IEnumerable<TopicViewModel>> Topics(HttpResponse response, HttpSession session)
        {
            AuthenticationManager.GetAuthenticatedUser(session.Id);
            IEnumerable<TopicViewModel> viewModels = this.service.GetLatestTopicViewModels();
            return this.View(viewModels);
        }

    }
}
