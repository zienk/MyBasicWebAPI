using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApiApp.Data;
using MyWebApiApp.Models;

namespace MyWebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly MyDbContext _context;

        public CategoriesController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var categories = _context.Categories.ToList();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var category = _context.Categories.SingleOrDefault(c => c.CategoryId == id);

            if (category == null)
            {
                return NotFound(new
                {
                    Success = false,
                    Message = "Category not found."
                });
            }
            return Ok(category);
        }

        [HttpPost]
        public IActionResult CreateNew(CategoryModel model)
        {
            try
            {
                var category = new Category()
                {
                    Name = model.Name
                };

                _context.Categories.Add(category);
                _context.SaveChanges();
                return Ok(category);
            }
            catch
            {
                return BadRequest(new
                {
                    Success = false,
                    Message = "Failed to create category."
                });
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCategoryById(int id, CategoryModel model)
        {
            var category = _context.Categories.SingleOrDefault(c => c.CategoryId == id);

            if (category != null)
            {
                category.Name = model.Name;
                _context.SaveChanges();
                return Ok(category);
            }
            else
            {
                return NotFound(new
                {
                    Success = false,
                    Message = "Category not found."
                });
            }

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategoryById(int id)
        {
            var category = _context.Categories.SingleOrDefault(c => c.CategoryId == id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
                return Ok(new
                {
                    Success = true,
                    Message = "Category deleted successfully."
                });
            }
            else
            {
                return NotFound(new
                {
                    Success = false,
                    Message = "Category not found."
                });
            }
        }
    }
}