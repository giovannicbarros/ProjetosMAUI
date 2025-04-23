using AppMAUIGallery.Models;
using AppMAUIGallery.Views.Layouts;

namespace AppMAUIGallery.Repositories
{
    internal class CategoryRepository
    {
        public CategoryRepository()
        {
                
        }

        public List<Category> GetCategories()
        {
            List<Category> categories = new List<Category>();
            categories.Add(new Category
            {
                Name = "Layout",
                Components = new List<Component> { 
                    new Component {
                        Title = "StackLayout",
                        Description = "Organização squencia dos elementos.",
                        Page = typeof(StackLayoutPage)
                    }
                }
            });

            return categories;
        }
    }
}
