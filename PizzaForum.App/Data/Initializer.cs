namespace PizzaForum.App.Data
{
    public static class Initializer
    {
        private static ForumContext context;

        public static ForumContext Context => context ?? (context = new ForumContext());
    }
}
