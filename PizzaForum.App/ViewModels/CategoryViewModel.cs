namespace PizzaForum.App.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            string content = "<tr>\r\n\t\t\t\t" +
                             $"<td><a href=\"#\">{this.Name}</a></td>\r\n\t\t\t\t" +
                             $"<td><a href=\"/categories/edit?id={this.Id}\" class=\"btn btn-primary\"/>Edit</a></td>\r\n\t\t\t\t" +
                             $"<td><a href=\"/categories/delete?id={this.Id}\" class=\"btn btn-danger\"/>Delete</a></td>\r\n\t\t\t" +
                             "</tr>";
            return content;
        }
    }
}
