namespace PizzaForum.App.Views.Forum
{
    using System.Text;
    using PizzaForum.App.Helpers;
    using SimpleMVC.Interfaces;

    public class Login : IRenderable
    {
        public string Render()
        {
            StringBuilder contentBuilder = new StringBuilder();
            contentBuilder.Append(ContentReader.Load(Constants.HeaderPath));
            contentBuilder.Append(ContentReader.Load(Constants.NavNotLoggedPath));
            contentBuilder.Append(ContentReader.Load(Constants.LoginPath));
            contentBuilder.Append(ContentReader.Load(Constants.FooterPath));
            return contentBuilder.ToString();
        }
    }
}
