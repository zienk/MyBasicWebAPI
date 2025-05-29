using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApiApp.Models;

namespace MyWebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public static List<Product> products = new List<Product>();

        [HttpGet]
         public IActionResult GetAll()
         {
            return Ok(products);
         }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                //LinQ [Object] Query
                var product = products.SingleOrDefault(p => p.Id == Guid.Parse(id));

                if (product == null)
                {
                    return NotFound(new
                    {
                        Success = false,
                        Message = "Product not found."
                    });
                }
                return Ok(product);
            } 
            catch
            {
                return BadRequest(); //Yêu cầu này ko hợp lệ    
            }
        }

        [HttpPost]
        public IActionResult Create(ProductVM productVM)
        {
            var product = new Product()
            {
                Id = Guid.NewGuid(),
                Name = productVM.Name,
                Price = productVM.Price
            };
            
            products.Add(product);

            return Ok(new
            {
                Success = true,
                Data = product,
            });

        }

        [HttpPut("{id}")]
        public IActionResult Edit(string id, Product productEdit)
        {
            try
            {
                //LinQ [Object] Query
                var product = products.SingleOrDefault(p => p.Id == Guid.Parse(id));

                if (product == null)
                {
                    return NotFound(new
                    {
                        Success = false,
                        Message = "Product not found."
                    });
                }
                if (id != product.Id.ToString())
                {
                    return BadRequest();
                }
                //Update
                product.Name = productEdit.Name;
                product.Price = productEdit.Price;

                return Ok();
            }
            catch
            {
                return BadRequest(); //Yêu cầu này ko hợp lệ    
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(string id)
        {
            try
            {
                var product = products.SingleOrDefault(p => p.Id == Guid.Parse(id));

                if (product == null)
                {
                    return NotFound(new
                    {
                        Success = false,
                        Message = "Product not found."
                    });
                }
                
                //Delete
                products.Remove(product); 
                return Ok();
            }
            catch
            {
                return BadRequest(); //Yêu cầu này ko hợp lệ
            }
        }

    }
}
