namespace PizzaForum.App.Attributes
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Text.RegularExpressions;

    [AttributeUsage(AttributeTargets.Property)]
    public class EmailAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string emailString = (string)value;

            if (emailString.Contains("@"))
            {
                return true;
            }

            return false;
        }
    }
}
