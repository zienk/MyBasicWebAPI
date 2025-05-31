using MyWebApiApp.Data;
using MyWebApiApp.Models;

namespace MyWebApiApp.Services
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MyDbContext _context;

        //Dependency Injection
        public CategoryRepository(MyDbContext context)
        {
            _context = context;
        }

        public CategoryVM Add(CategoryModel category)
        {
            var categoryEntity = new Category
            {
                Name = category.Name
            };
            _context.Add(categoryEntity);
            _context.SaveChanges();
            return new CategoryVM
            {
                CategoryId = categoryEntity.CategoryId,
                Name = categoryEntity.Name
            };
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<CategoryVM> GetAll()
        {
            var categories = _context.Categories.Select(category => new CategoryVM
            {
                CategoryId = category.CategoryId,
                Name = category.Name
            });
            return categories.ToList();
        }

        public CategoryVM GetById(int id)
        {
            var category = _context.Categories.SingleOrDefault(c => c.CategoryId == id);
            if (category != null)
            {
                return new CategoryVM
                {
                    CategoryId = category.CategoryId,
                    Name = category.Name
                };
            }
            return null; 
        }

        public void Update(CategoryVM category)
        {
            throw new NotImplementedException();
        }
    }
}
