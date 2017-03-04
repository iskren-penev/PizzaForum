namespace PizzaForum.App.Data
{
    public static class Initializer
    {
        private static UnitOfWork unitOfWork;

        public static UnitOfWork UnitOfWork => unitOfWork ?? (unitOfWork = new UnitOfWork(new ForumContext()));
    }
}
