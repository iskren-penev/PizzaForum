namespace PizzaForum.App.Controllers
{
    using System.Collections;
    using System.Collections.Generic;
    using PizzaForum.App.BindingModels;
    using PizzaForum.App.Models;
    using PizzaForum.App.Security;
    using PizzaForum.App.Services;
    using PizzaForum.App.ViewModels;
    using SimpleHttpServer.Models;
    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces;
    using SimpleMVC.Interfaces.Generic;

    public class CategoriesController : Controller
    {
        private CatergoriesService service;

        public CategoriesController()
        {
            this.service = new CatergoriesService();
        }

        [HttpGet]
        public IActionResult<IEnumerable<CategoryViewModel>> All(HttpResponse response, HttpSession session)
        {
            User activeUser = GetAuthenticatedUser(response, session);
            IEnumerable<CategoryViewModel> categories = this.service.GetAllCategoryViewModels();
            return this.View(categories);
        }

        [HttpGet]
        public IActionResult New(HttpResponse response, HttpSession session)
        {
            GetAuthenticatedUser(response, session);
            return this.View();
        }

        [HttpPost]
        public void New(HttpResponse response, HttpSession session, AddCategoryBindingModel model)
        {
            GetAuthenticatedUser(response, session);
            if (!this.service.IsModelValid(model))
            {
                Redirect(response, "/categories/new");
            }

            this.service.AddNewCategory(model);
            Redirect(response, "/categories/all");
        }

        [HttpGet]
        public void Delete(HttpResponse response, HttpSession session, int id)
        {
            GetAuthenticatedUser(response, session);
            this.service.DeleteCategory(id);
            Redirect(response, "/categories/all");
        }

        [HttpGet]
        public IActionResult<EditCategoryViewModel> Edit(HttpResponse response, HttpSession session, int id)
        {
            User user = GetAuthenticatedUser(response, session);
            if (user == null)
            {
                return null;
            }
            if (!this.service.IsCategoryIdValid(id))
            {
                Redirect(response, "/categories/all");
            }
            EditCategoryViewModel viewModel = this.service.GetEditCategoryViewModel(id);
            return this.View(viewModel);
        }

        [HttpPost]
        public void Edit(HttpResponse response, HttpSession session, EditCategoryBindingModel model)
        {
            User user = GetAuthenticatedUser(response, session);
            if (user == null)
            {
                return;
            }
            this.service.EditCategory(model);
            Redirect(response, "/categories/all");

        }

        private User GetAuthenticatedUser(HttpResponse response, HttpSession session)
        {
            if (!AuthenticationManager.IsAuthenticated(session))
            {
                this.Redirect(response, "/forum/login");
                return null;
            }

            User activeUser = AuthenticationManager.GetAuthenticatedUser(session.Id);
            if (!activeUser.IsAdmin)
            {
                this.Redirect(response, "/home/topics");
            }

            return activeUser;
        }
    }
}
