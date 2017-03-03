namespace PizzaForum.App.BindingModels
{
    public class EditCategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            string content = "<form method=\"POST\" action=\"/categories/edit\">\r\n\t\t" +
                             "<label>Name</label>\r\n\t\t<div class=\"form-group\">\r\n\t\t\t" +
                             $"<input type=\"hidden\" hidden=\"hidden\" class=\"form-control\" value=\"{this.Id}\" name=\"Id\">\r\n\t\t\t" +
                             $"<input type=\"text\" class=\"form-control\" value=\"{this.Name}\" name=\"Name\"/>\r\n\t\t" +
                             $"</div>\r\n\t\t<input type=\"submit\" class=\"btn btn-primary\" value=\"Edit Category\"/>\r\n\t" +
                             $"</form>";
            return content;
        }
    }
}
