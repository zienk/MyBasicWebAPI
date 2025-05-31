using MyWebApiApp.Models;

namespace MyWebApiApp.Services
{
    public interface ICategoryRepository
    {
        //Định nghĩa các method: Thêm, xóa, sửa, lấy
        
        List <CategoryVM> GetAll();
        CategoryVM GetById(int id);
        CategoryVM Add(CategoryModel category);
        void Update(CategoryVM category);

        void Delete(int id);

    }
}
