namespace PizzaForum.App.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using PizzaForum.App.BindingModels;
    using PizzaForum.App.Models;
    using PizzaForum.App.ViewModels;

    public class CatergoriesService : Service
    {
        public IEnumerable<CategoryViewModel> GetAllCategoryViewModels()
        {
            IEnumerable<CategoryViewModel> categories =
                this.context.Categories.Select(category => new CategoryViewModel()
                {
                    Id = category.Id,
                    Name = category.Name
                });

            return categories;
        }

        public bool IsModelValid(AddCategoryBindingModel model)
        {
            if (string.IsNullOrEmpty(model.Name) || string.IsNullOrWhiteSpace(model.Name))
            {
                return false;
            }
            return true;
        }

        public void AddNewCategory(AddCategoryBindingModel model)
        {
            Category category = new Category()
            {
                Name = model.Name
            };
            this.context.Categories.Add(category);
            this.context.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            this.context.Categories.Remove(this.context.Categories.Find(id));
            this.context.SaveChanges();
        }

        public bool IsCategoryIdValid(int id)
        {
            if (!this.context.Categories.Any(c=> c.Id == id))
            {
                return false;
            }
            return true;
        }

        public EditCategoryViewModel GetEditCategoryViewModel(int id)
        {
            Category category = this.context.Categories.Find(id);
            EditCategoryViewModel viewModel = new EditCategoryViewModel()
            {
                Id = category.Id,
                Name = category.Name
            };
            return viewModel;
        }

        public void EditCategory(EditCategoryBindingModel model)
        {
            Category category = this.context.Categories.Find(model.Id);
            category.Name = model.Name;
            this.context.SaveChanges();
        }
    }
}
