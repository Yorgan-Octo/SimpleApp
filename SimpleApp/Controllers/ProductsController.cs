using Microsoft.AspNetCore.Mvc;
using SimpleApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace SimpleApp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductReader _reader;

        public ProductsController()
        {
            _reader = new ProductReader();
        }

        public IActionResult List(string? id)
        {
            if (id != null)
            {

                List<Product> products = _reader.ReadFromFile().Where(x => x.Catecory.ToLower() == id.ToLower()).ToList();
                return View(products);

            }
            else
            {
                List<Product> products = _reader.ReadFromFile();
                return View(products);
            }
        }

        // Products/Details/1
        public IActionResult Details(int id)
        {
            List<Product> products = _reader.ReadFromFile();
            Product product = products.Where(x => x.Id == id).FirstOrDefault();

            if (product != null)
            {

                return View(product);
            }
            else
            {
                return NotFound();
            }
        }
    }
}