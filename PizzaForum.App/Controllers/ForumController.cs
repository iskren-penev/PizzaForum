namespace PizzaForum.App.Controllers
{
    using PizzaForum.App.BindingModels;
    using PizzaForum.App.Security;
    using PizzaForum.App.Services;
    using SimpleHttpServer.Models;
    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces;

    public class ForumController : Controller
    {
        private ForumService service;

        public ForumController()
        {
            this.service = new ForumService();
        }

        [HttpGet]
        public IActionResult Register(HttpResponse response, HttpSession session)
        {
            if (AuthenticationManager.IsAuthenticated(session))
            {
                Redirect(response, "/home/topics");
                return null;
            }
            return this.View();
        }

        [HttpPost]
        public IActionResult Register(HttpResponse response,HttpSession session, RegisterUserBindingModel model)
        {
            if (AuthenticationManager.IsAuthenticated(session))
            {
                Redirect(response, "/home/topics");
                return null;
            }

            bool registerSuccess = service.RegisterUser(model);
            if (!registerSuccess)
            {
                Redirect(response, "/forum/register");
                return null;
            }
            Redirect(response, "/forum/login");
            return null;
        }

        [HttpGet]
        public IActionResult Login(HttpResponse response, HttpSession session)
        {
            if (AuthenticationManager.IsAuthenticated(session))
            {
                Redirect(response, "/home/topics");
                return null;
            }
            return this.View();
        }

        [HttpPost]
        public IActionResult Login(HttpResponse response, HttpSession session, LoginUserBindingModel model)
        {
            if (AuthenticationManager.IsAuthenticated(session))
            {
                Redirect(response, "/home/topics");
                return null;
            }

            if (!this.service.IsValidUser(model))
            {
                Redirect(response, "/forum/login");
                return null;
            }

            service.LoginUser(session, model);
            Redirect(response, "/home/topics");
            return null;
        }

        public void Logout(HttpResponse response, HttpSession session)
        {
            AuthenticationManager.Logout(response, session.Id);
            Redirect(response, "/home/topics");
        }

    }
}
