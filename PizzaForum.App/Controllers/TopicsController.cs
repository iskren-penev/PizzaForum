namespace PizzaForum.App.Controllers
{
    using System.Collections.Generic;
    using PizzaForum.App.BindingModels;
    using PizzaForum.App.Models;
    using PizzaForum.App.Security;
    using PizzaForum.App.Services;
    using SimpleHttpServer.Models;
    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces.Generic;

    public class TopicsController : Controller
    {
        private TopicService service;

        public TopicsController()
        {
            this.service= new TopicService();
        }

        [HttpGet]
        public IActionResult<IEnumerable<string>> New(HttpResponse response, HttpSession session)
        {
            User currentUser = AuthenticationManager.GetAuthenticatedUser(session.Id);
            if (currentUser == null)
            {
                Redirect(response, "/home/topics");
                return null;
            }

            IEnumerable<string> categoryNames = this.service.GetCategoryNames();

            return this.View(categoryNames);
        }

        [HttpPost]
        public void New(HttpResponse response, HttpSession session, NewTopicBindingModel model)
        {
            User currentUser = AuthenticationManager.GetAuthenticatedUser(session.Id);
            if (currentUser == null)
            {
                Redirect(response, "/home/topics");
                return;
            }

            if (!this.service.IsValidNewTopicModel(model))
            {
                Redirect(response, "/topics/new");
                return;
            }

            this.service.AddNewTopic(model, currentUser);
            Redirect(response, "/home/topics");
            
        }
        //TODO: DETAILS PAGE + HOME/CATEGORIES
    }
}
