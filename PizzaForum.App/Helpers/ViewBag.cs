﻿namespace PizzaForum.App.Helpers
{
    using System.Collections.Generic;

    public static class ViewBag
    {
        public static Dictionary<string, dynamic> Bag = new Dictionary<string, dynamic>();

        public static dynamic GetUserName()
        {
            if (Bag.ContainsKey("username"))
            {
                return Bag["username"];
            }

            return null;
        }
    }
}
