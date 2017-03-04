namespace PizzaForum.App.Views.Home
{
    using System.Collections.Generic;
    using System.Text;
    using PizzaForum.App.Helpers;
    using PizzaForum.App.Models;
    using PizzaForum.App.ViewModels;
    using SimpleMVC.Interfaces.Generic;
    public class Topics : IRenderable<IEnumerable<TopicViewModel>>
    {
        public string Render()
        {
            string topicsList = string.Join(" ", Model);
            string navigation = ContentReader.Load(Constants.NavNotLoggedPath);
            string currentUser = ViewBag.GetUserName();
            if (currentUser != null)
            {
                navigation = string.Format(ContentReader.Load(Constants.NavLoggedPath), ViewBag.Bag["username"]);
            }

            StringBuilder contentBuilder = new StringBuilder();
            contentBuilder.Append(ContentReader.Load(Constants.HeaderPath));
            contentBuilder.Append(navigation);
            contentBuilder.Append("<div class=\"container\">");
            if (currentUser != null)
            {
                contentBuilder.Append(ContentReader.Load(Constants.TopicNewButtonPath));
                contentBuilder.Append("<p></P>");
            }
            contentBuilder.Append(topicsList);
            contentBuilder.Append("</div>");
            contentBuilder.Append(ContentReader.Load(Constants.FooterPath));
            return contentBuilder.ToString();
        }

        public IEnumerable<TopicViewModel> Model { get; set; }
    }
}
