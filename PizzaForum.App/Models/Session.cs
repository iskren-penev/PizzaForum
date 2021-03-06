﻿namespace PizzaForum.App.Models
{
    public class Session
    {
        public string Id { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public bool IsActive { get; set; }
    }
}
