namespace PizzaForum.App.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using PizzaForum.App.BindingModels;
    using PizzaForum.App.Models;

    public class TopicService : Service
    {
        public IEnumerable<string> GetCategoryNames()
        {
            IEnumerable<string> categories = this.context.Categories.Select(cat => cat.Name);

            return categories;
        }

        public bool IsValidNewTopicModel(NewTopicBindingModel model)
        {
            if (model.Title.Length > 30)
            {
                return false;
            }
            if (model.Content.Length > 5000)
            {
                return false;
            }
            return true;
        }

        public void AddNewTopic(NewTopicBindingModel model, User currentUser)
        {
            Category category = this.context.Categories.FirstOrDefault(cat => cat.Name == model.Category);
            Topic topic = new Topic()
            {
                Title = model.Title,
                Category = category,
                Author = currentUser,
                Content = model.Content,
                PublishDate = DateTime.Now
            };
            this.context.Topics.Add(topic);
            this.context.SaveChanges();
        }
    }
}
