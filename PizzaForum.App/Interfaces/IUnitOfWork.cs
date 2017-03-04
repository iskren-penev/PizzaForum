namespace PizzaForum.App.Interfaces
{
    using PizzaForum.App.Models;

    public interface IUnitOfWork
    {
        IRepository<User> Users { get; }

        IRepository<Topic> Topics { get; }

        IRepository<Session> Sessions { get; }

        IRepository<Category> Categories { get; }

        IRepository<Reply> Replies { get; }
    }
}
