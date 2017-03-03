using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaForum.App.Models
{
    public class Category
    {
        private ICollection<Topic> topics;

        public Category()
        {
            this.topics = new List<Topic>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Topic> Topics
        {
            get { return this.topics; }
            set { this.topics = value; }
        }
    }
}
