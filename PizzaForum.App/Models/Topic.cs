namespace PizzaForum.App.Models
{
    using System;
    using System.Collections.Generic;

    public class Topic
    {
        private ICollection<Reply> replies;

        public Topic()
        {
            this.replies = new List<Reply>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public int? AuthorId { get; set; }

        public virtual User Author { get; set; }

        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public string Content { get; set; }

        public DateTime PublishDate { get; set; }

        public virtual ICollection<Reply> Replies
        {
            get {return this.replies;}
            set { this.replies = value; }
        }

    }
}
