namespace PizzaForum.App.Data
{
    using PizzaForum.App.Interfaces;
    using PizzaForum.App.Models;

    public    class UnitOfWork : IUnitOfWork
    {
        private readonly ForumContext context;
        private IRepository<User> users;
        private IRepository<Topic> topics;
        private IRepository<Session> sessions;
        private IRepository<Category> categories;
        private IRepository<Reply> replies;

        public UnitOfWork(ForumContext context)
        {
            this.context = context;
        }

        public IRepository<User> Users
        {
            get { return this.users ?? (this.users = new Repository<User>(this.context.Users)); }
        }
        public IRepository<Topic> Topics
        {
            get { return this.topics ?? (this.topics = new Repository<Topic>(this.context.Topics)); }
        }
        public IRepository<Session> Session
        {
            get { return this.sessions ?? (this.sessions = new Repository<Session>(this.context.Sessions)); }
        }
        public IRepository<Category> Categories
        {
            get { return this.categories ?? (this.categories = new Repository<Category>(this.context.Categories)); }
        }
        public IRepository<Reply> Replies
        {
            get { return this.replies ?? (this.replies = new Repository<Reply>(this.context.Replies)); }
        }

        public void Commit()
        {
            this.context.SaveChanges();
        }
    }
}
