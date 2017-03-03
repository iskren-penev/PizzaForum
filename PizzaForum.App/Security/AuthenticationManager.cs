namespace PizzaForum.App.Security
{
    using System.Linq;
    using System.Runtime.Remoting.Contexts;
    using PizzaForum.App.Helpers;
    using PizzaForum.App.Models;
    using SimpleHttpServer.Models;
    using SimpleHttpServer.Utilities;

    public class AuthenticationManager
    {

        public static bool IsAuthenticated(HttpSession session)
        {
            return Data.Initializer.Context.Sessions.Any(s => s.Id == session.Id && s.IsActive);
        }
        public static User GetAuthenticatedUser(string sessionId)
        {
            User user = Data.Initializer.Context.Sessions.FirstOrDefault(s => s.Id == sessionId && s.IsActive)?.User;
            if (user != null)
            {
                ViewBag.Bag["username"] = user.Username;
            }

            return user;
        }

        public static void Logout(HttpResponse response, string sessionId)
        {
            ViewBag.Bag["username"] = null;
            Session currentLogin = Data.Initializer.Context.Sessions.FirstOrDefault(s => s.Id == sessionId);
            currentLogin.IsActive = false;
            Data.Initializer.Context.SaveChanges();

            var session = SessionCreator.Create();
            var sessionCookie = new Cookie("sessionId", session.Id + "; HttpOnly; path=/");
            response.Header.AddCookie(sessionCookie);
        }
    }
}
