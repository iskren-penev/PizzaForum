namespace PizzaForum.App.Services
{
    using PizzaForum.App.Data;

    public abstract class Service
    {
        protected ForumContext context;

        protected Service()
        {
            this.context = Data.Initializer.Context;
        }
    }
}
