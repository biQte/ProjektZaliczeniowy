using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjektZaliczeniowy.Data;
using ProjektZaliczeniowy.Models;
using ProjektZaliczeniowy.Models.Entities;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace ProjektZaliczeniowy.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _dbContext;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (!_dbContext.Users.Any())
            {
                var adminUsername = "admin";
                var adminPassword = GenerateRandomPassword();

                var adminUser = new User
                {
                    Username = adminUsername,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(adminPassword),
                    Role = "Admin",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                };

                _dbContext.Users.Add(adminUser);

                await _dbContext.SaveChangesAsync();

                ViewBag.Message = "Domyœlne konto administratora zosta³o utworzone.";
                ViewBag.Username = adminUsername;
                ViewBag.Password = adminPassword;
                ViewBag.Note = "Proszê zapisaæ te dane, poniewa¿ nie bêd¹ dostêpne ponownie!";
                return View("FirstRun");
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Products()
        {
            var products = _dbContext.Products.ToList();
            return View(products);
        }

        [HttpPost]
        public IActionResult DeleteProduct(int id)
        {
            var product = _dbContext.Products.Find(id);
            if (product != null)
            {
                _dbContext.Products.Remove(product);
                _dbContext.SaveChanges();
            }
            return RedirectToAction("Products");
        }

        public IActionResult EditProduct(int id)
        {
            var product = _dbContext.Products.Find(id);
            if (product == null)
            {
                return Error();
            }
            ViewBag.ProductId = product.Id;
            ViewBag.ProductName = product.Name;
            ViewBag.WarehouseLocation = product.WarehouseLocation;
            return View();
        }

        [HttpPost]
        public IActionResult EditProduct(int id, string name, string warehouseLocation)
        {
            if (name == null || warehouseLocation == null)
            {
                ViewBag.Error = "Wszystkie pola s¹ wymagane.";
                ViewBag.ProductId = id;
                return View();
            }

            var product = _dbContext.Products.Find(id);

            if (product == null)
            {
                return Error();
            }

            product.Name = name;
            product.WarehouseLocation = warehouseLocation;

            _dbContext.SaveChanges();
            return RedirectToAction("Products");
        }

        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(string name, string ean, string sku, string warehouseLocation)
        {
            if(ean == null || sku == null || name == null || warehouseLocation == null)
            {
                ViewBag.Error = "Wszystkie pola s¹ wymagane.";
                return View();
            }

            if(Regex.IsMatch(ean, @"^\d{13}$") == false)
            {
                ViewBag.Error = "EAN musi sk³adaæ siê z 13 cyfr.";
                return View();
            }

            var products = await _dbContext.Products.FirstOrDefaultAsync(p => p.Ean == ean || p.CatalogNumber == sku);
            if (products != null)
            {
                ViewBag.Error = "Produkt o podanym EAN lub numerze katalogowym ju¿ istnieje.";
                return View();
            }

            var product = new Product
            {
                Name = name,
                Ean = ean,
                CatalogNumber = sku,
                WarehouseLocation = warehouseLocation,
                QuantityInStock = 0,
                ProductType = "TP",
                UnitOfMeasure = "szt."
            };

            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
            return RedirectToAction("Products");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private string GenerateRandomPassword(int length = 12)
        {
            const string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()";
            var password = new StringBuilder();
            using (var rng = RandomNumberGenerator.Create())
            {
                byte[] buffer = new byte[1];
                while (password.Length < length)
                {
                    rng.GetBytes(buffer);
                    char character = (char)buffer[0];
                    if (validChars.Contains(character))
                    {
                        password.Append(character);
                    }
                }
            }
            return password.ToString();
        }
    }
}
