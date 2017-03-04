namespace PizzaForum.App.Models
{
    using System.Collections.Generic;


    public class User
    {
        private ICollection<Topic> topics;
        private ICollection<Reply> replies;

        public User()
        {
            this.topics = new List<Topic>();
        }

        public int Id { get; set; }
        
        public string Username { get; set; }
        
        public string Email { get; set; }
        
        public string Password { get; set; }

        public bool IsAdmin { get; set; }

        public virtual ICollection<Topic> Topics
        {
            get {return this.topics;}
            set { this.topics = value; }
        }

        public virtual ICollection<Reply> Replies
        {
            get { return this.replies; }
            set { this.replies = value; }
        }
    }
}
