namespace PizzaForum.App.Controllers
{
    using PizzaForum.App.BindingModels;
    using PizzaForum.App.Services;
    using SimpleHttpServer.Models;
    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces;

    public class ForumController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Register(HttpResponse response, RegisterUserBindingModel model)
        {
            UserService service = new UserService(Data.Initializer.Context);
            bool registerSuccess = service.Register(model);
            if (!registerSuccess)
            {
                Redirect(response, "/forum/register");
            }
            Redirect(response, "/forum/login");
            return null;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Login(HttpResponse response, HttpSession session, LoginUserBindingModel model)
        {
            UserService service = new UserService(Data.Initializer.Context);
            service.Login(session, model);
            Redirect(response, "/forum/login");
            return null;
        }
    }
}
