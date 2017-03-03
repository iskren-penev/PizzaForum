namespace PizzaForum.App.Attributes
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    [AttributeUsage(AttributeTargets.Property)]
    public class UsernameAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string usernameAsString = value as string;
            if (usernameAsString.Length < 3)
            {
                return false;
            }
            if ((usernameAsString.Count(char.IsLower) + usernameAsString.Count(char.IsControl)) != usernameAsString.Length)
            {
                return false;
            }
            return true;
        }

    }


}
