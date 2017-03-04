namespace PizzaForum.App.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using PizzaForum.App.ViewModels;

    public class HomeService: Service
    {
        public IEnumerable<TopicViewModel> GetLatestTopicViewModels()
        {
            IEnumerable<TopicViewModel> viewModels = this.context.Topics.GetAll()
                .OrderByDescending(t => t.PublishDate)
                .Take(10)
                .Select(topic => new TopicViewModel()
            {
                Id = topic.Id,
                Title = topic.Title,
                Author = topic.Author.Username,
                Category = topic.Category.Name,
                PublishDate = topic.PublishDate,
                RepliesCount = topic.Replies.Count
            });
            return viewModels;
        }
    }
}
