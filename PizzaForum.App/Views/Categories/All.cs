namespace PizzaForum.App.Views.Categories
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;
    using PizzaForum.App.Helpers;
    using PizzaForum.App.ViewModels;
    using SimpleMVC.Interfaces;
    using SimpleMVC.Interfaces.Generic;

    public class All : IRenderable<IEnumerable<CategoryViewModel>>
    {
        public string Render()
        {
            string categoriesList = string.Join(" ", Model);
            string categories = string.Format(ContentReader.Load(Constants.AdminCategoriesPath), categoriesList);
            string navigation = string.Format(ContentReader.Load(Constants.NavLoggedPath), ViewBag.Bag["username"]);

            StringBuilder contentBuilder = new StringBuilder();
            contentBuilder.Append(ContentReader.Load(Constants.HeaderPath));
            contentBuilder.Append(navigation);
            contentBuilder.Append(categories);
            contentBuilder.Append(ContentReader.Load(Constants.FooterPath));
            return contentBuilder.ToString();
        }

        public IEnumerable<CategoryViewModel> Model { get; set; }
    }
}
