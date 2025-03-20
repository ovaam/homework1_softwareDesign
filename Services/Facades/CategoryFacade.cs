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

        public Category GetCategory(int id)
        {
            return categories.FirstOrDefault(c => c.Id == id);
        }

        public void UpdateCategory(Category category)
        {
            var existingCategory = categories.FirstOrDefault(c => c.Id == category.Id);
            if (existingCategory != null)
            {
                existingCategory.Name = category.Name;
                existingCategory.Type = category.Type;
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
    }
}