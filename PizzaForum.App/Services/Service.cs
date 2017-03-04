namespace PizzaForum.App.Services
{
    using PizzaForum.App.Data;

    public abstract class Service
    {
        protected UnitOfWork context;

        protected Service()
        {
            this.context = Data.Initializer.UnitOfWork;
        }
    }
}
