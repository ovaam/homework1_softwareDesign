using bigHomeWork.Domain;

namespace bigHomeWork.Services.Facades
{
    public class CategoryFacade
    {
        private List<Category> categories = new List<Category>();

        public void AddCategory(Category category)
        {
            categories.Add(category);
        }

        public void EditCategory(int id, string newType, string newName)
        {
            var category = categories.FirstOrDefault(c => c.Id == id);
            if (category != null)
            {
                category.Type = newType;
                category.Name = newName;
            }
        }

        public void DeleteCategory(int id)
        {
            var category = categories.FirstOrDefault(c => c.Id == id);
            if (category != null)
            {
                categories.Remove(category);
            }
        }

        public List<Category> GetCategories()
        {
            return categories;
        }
    }
}