namespace PizzaForum.App.Helpers
{
    using System.IO;

    public static class ContentReader
    {
        public static string Load(string path)
        {
            string content = File.ReadAllText(path);

            return content;
        }

        public static byte[] LoadContent(string path)
        {
            byte[] content = File.ReadAllBytes(path);

            return content;
        }
    }
}
