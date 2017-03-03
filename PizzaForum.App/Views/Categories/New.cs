namespace PizzaForum.App.Views.Categories
{
    using System.Text;
    using PizzaForum.App.Helpers;
    using SimpleMVC.Interfaces;
    public class New : IRenderable
    {
        public string Render()
        {
            string navigation = string.Format(ContentReader.Load(Constants.NavLoggedPath), ViewBag.Bag["username"]);

            StringBuilder contentBuilder = new StringBuilder();
            contentBuilder.Append(ContentReader.Load(Constants.HeaderPath));
            contentBuilder.Append(navigation);
            contentBuilder.Append(ContentReader.Load(Constants.AdminCategoryNewPath));
            contentBuilder.Append(ContentReader.Load(Constants.FooterPath));
            return contentBuilder.ToString();
        }
    }
}
