namespace PizzaForum.App.Models
{
    using System;

    public class Reply
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public int? AuthorId { get; set; }

        public virtual User Author { get; set; }
        
        public DateTime PublishDate { get; set; }
    }
}
