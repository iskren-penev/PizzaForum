namespace PizzaForum.App.Services
{
    using System.Linq;
    using System.Text.RegularExpressions;
    using PizzaForum.App.BindingModels;
    using PizzaForum.App.Models;
    using SimpleHttpServer.Models;

    public class ForumService : Service
    {

        public bool RegisterUser(RegisterUserBindingModel model)
        {
            if (!IsValidUser(model))
            {
                return false;
            }
            User userEntity = new User()
            {
                Username = model.Username,
                Email = model.Email,
                Password = model.Password,
                IsAdmin = this.IsFirstRegisteredUser()
            };
            this.context.Users.Add(userEntity);
            this.context.SaveChanges();
            return true;
        }

        public void LoginUser(HttpSession session, LoginUserBindingModel model)
        {
            User user = this.context.Users.FirstOrDefault(u => (u.Username == model.UserInput || u.Email == model.UserInput) && u.Password == model.Password);

            Session dbSession = new Session()
            {
                Id = session.Id,
                User = user,
                IsActive = true
            };

            this.context.Sessions.Add(dbSession);
            this.context.SaveChanges();

        }

        public bool IsValidUser(LoginUserBindingModel model)
        {
            return
                this.context.Users.Any(
                    u => (u.Username == model.UserInput || u.Email == model.UserInput) && u.Password == model.Password);
        }
        private bool IsValidUser(RegisterUserBindingModel model)
        {
            //check if the password and confirmed password match
            if (model.Password != model.ConfirmPassword)
            {
                return false;
            }
            //check if there is already registered user with the same email or username
            int usersCount = this.context.Users.Count(u => u.Username == model.Username || u.Email == model.Email);
            if (usersCount != 0)
            {
                return false;
            }
            //check if the email, password and username are valid
            if (!model.Email.Contains("@") || !PasswordCheck(model.Password) || !UsernameCheck(model.Username))
            {
                return false;
            }
            return true;
        }

        //check if there are any users in the DB
        private bool IsFirstRegisteredUser()
        {
            if (this.context.Users.Any())
            {
                return false;
            }
            return true;
        }
        //password must be exactly 4 symbols long and must contain only digits
        private bool PasswordCheck(string password)
        {
            Regex passwordRegex = new Regex("^[0-9]{4}$");
            if (passwordRegex.IsMatch(password))
            {
                return true;
            }
            return false;
        }

        //minimum length is 3, must contain only lowercase lettes and digits
        private bool UsernameCheck(string username)
        {
            Regex usernameRegex = new Regex("^[a-z0-9]{3,}$");
            if (usernameRegex.IsMatch(username))
            {
                return true;
            }
            return false;
        }
    }
}
