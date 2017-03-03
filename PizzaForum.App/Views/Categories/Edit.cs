namespace PizzaForum.App.Views.Categories
{
    using System.Text;
    using PizzaForum.App.BindingModels;
    using PizzaForum.App.Helpers;
    using SimpleMVC.Interfaces.Generic;
    public class Edit : IRenderable<EditCategoryViewModel>
    {
        public string Render()
        {
            string editCategory = string.Format(ContentReader.Load(Constants.AdminCategoryEditPath), Model);
            string navigation = string.Format(ContentReader.Load(Constants.NavLoggedPath), ViewBag.Bag["username"]);

            StringBuilder contentBuilder = new StringBuilder();
            contentBuilder.Append(ContentReader.Load(Constants.HeaderPath));
            contentBuilder.Append(navigation);
            contentBuilder.Append(editCategory);
            contentBuilder.Append(ContentReader.Load(Constants.FooterPath));
            return contentBuilder.ToString();
        }

        public EditCategoryViewModel Model { get; set; }
    }
}
