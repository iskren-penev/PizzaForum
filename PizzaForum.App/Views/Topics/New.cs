namespace PizzaForum.App.Views.Topics
{
    using System.Collections.Generic;
    using System.Text;
    using PizzaForum.App.Helpers;
    using SimpleMVC.Interfaces.Generic;

    public class New : IRenderable<IEnumerable<string>>
    {
        public string Render()
        {
            StringBuilder categoriesList = new StringBuilder();
            foreach (string categoryName in Model)
            {
                categoriesList.Append($"<option value=\"{categoryName}\">{categoryName}</option>");
            }
            string topicNew = string.Format(ContentReader.Load(Constants.TopicNewPath), categoriesList);
            string navigation = string.Format(ContentReader.Load(Constants.NavLoggedPath), ViewBag.Bag["username"]);

            StringBuilder contentBuilder = new StringBuilder();
            contentBuilder.Append(ContentReader.Load(Constants.HeaderPath));
            contentBuilder.Append(navigation);
            contentBuilder.Append(topicNew);
            contentBuilder.Append(ContentReader.Load(Constants.FooterPath));
            return contentBuilder.ToString();
        }

        public IEnumerable<string> Model { get; set; }
    }
}
