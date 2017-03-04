namespace PizzaForum.App.ViewModels
{
    using System;

    public class TopicViewModel
    {

        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Category { get; set; }

        public DateTime PublishDate { get; set; }

        public int RepliesCount { get; set; }

        public override string ToString()
        {
            string content = "<div class=\"thumbnail\">" +
                             $"<h4><strong><a href=\"/topics/details?id={this.Id}\">{this.Title}</a><strong> <small><a href=\"#\">{this.Category}</a></small></h4>" +
                             $"<p><a href=\"#\">{this.Author}</a> | Replies: {this.RepliesCount} | {this.PublishDate}</p></div>";
            return content;
        }
    }
}
