using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjektZaliczeniowy.Data;
using ProjektZaliczeniowy.Models;
using ProjektZaliczeniowy.Models.Entities;
using System.Diagnostics;
using System.Security.Claims;
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

        public async Task<IActionResult> ExternalIssues()
        {
            var externalIssues = await _dbContext.ExternalIssues.Include(e => e.User).Include(e => e.Details).ToListAsync();
            return View(externalIssues);
        }

        public async Task<IActionResult> CreateExternalIssue()
        {
            var products = await _dbContext.Products.ToListAsync();
            ViewBag.Products = products;
            return View(products);
        }

        [HttpPost]
        public async Task<IActionResult> CreateExternalIssue(string remarks, List<int> productIds, List<decimal> quantities)
        {
            if(productIds == null || productIds.Count == 0 || quantities == null || quantities.Count == 0)
            {
                ViewBag.Error = "Nale¿y wybraæ produkty i podaæ iloœci.";
                return View();
            }

            var userId = User.FindFirst(ClaimTypes.Sid)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("Nie mo¿na zidentyfikowaæ u¿ytkownika.");
            }

            var externalIssue = new ExternalIssue
            {
                Date = DateTime.UtcNow,
                Remarks = remarks,
                UserId = int.Parse(userId),
                Details = productIds.Select((productId, index) => new ExternalIssueDetail
                {
                    ProductId = productId,
                    Quantity = quantities[index]
                }).ToList(),
            };

            _dbContext.ExternalIssues.Add(externalIssue);
            foreach (var detail in externalIssue.Details)
            {
                var product = await _dbContext.Products.FindAsync(detail.ProductId);
                if (product != null)
                {
                    product.QuantityInStock += detail.Quantity;
                }
            }

            await _dbContext.SaveChangesAsync();

            return RedirectToAction("ExternalIssues");
        }

        public async Task<IActionResult> ExternalIssueDetails(int id)
        {
            var externalIssue = await _dbContext.ExternalIssues.Include(e => e.User).Include(e => e.Details).ThenInclude(d => d.Product).FirstOrDefaultAsync(e => e.Id == id);

            return View(externalIssue);
        }

        public async Task<IActionResult> InternalIssues()
        {
            var internalIssues = await _dbContext.InternalIssues.Include(i => i.User).Include(i => i.Details).ToListAsync();
            return View(internalIssues);
        }

        public async Task<IActionResult> CreateInternalIssue()
        {
            var products = await _dbContext.Products.ToListAsync();
            ViewBag.Products = products;
            return View(products);
        }

        [HttpPost]
        public async Task<IActionResult> CreateInternalIssue(string remarks, List<int> productIds, List<decimal> quantities)
        {
            if (productIds == null || productIds.Count == 0 || quantities == null || quantities.Count == 0)
            {
                ViewBag.Error = "Nale¿y wybraæ produkty i podaæ iloœci.";
                return View();
            }

            var userId = User.FindFirst(ClaimTypes.Sid)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("Nie mo¿na zidentyfikowaæ u¿ytkownika.");
            }

            var internalIssue = new InternalIssue
            {
                Date = DateTime.UtcNow,
                Remarks = remarks,
                UserId = int.Parse(userId),
                Details = productIds.Select((productId, index) => new InternalIssueDetail
                {
                    ProductId = productId,
                    Quantity = quantities[index]
                }).ToList(),
            };

            _dbContext.InternalIssues.Add(internalIssue);
            foreach (var detail in internalIssue.Details)
            {
                var product = await _dbContext.Products.FindAsync(detail.ProductId);
                if (product != null)
                {
                    product.QuantityInStock += detail.Quantity;
                }
            }

            await _dbContext.SaveChangesAsync();

            return RedirectToAction("InternalIssues");
        }

        public async Task<IActionResult> InternalIssueDetails(int id)
        {
            var internalIssue = await _dbContext.InternalIssues.Include(i => i.User).Include(i => i.Details).ThenInclude(d => d.Product).FirstOrDefaultAsync(i => i.Id == id);

            return View(internalIssue);
        }

        public async Task<IActionResult> ExternalReceipts()
        {
            var externalReceipts = await _dbContext.ExternalReceipts.Include(i => i.User).Include(i => i.Details).ToListAsync();
            return View(externalReceipts);
        }

        public async Task<IActionResult> CreateExternalReceipt()
        {
            var products = await _dbContext.Products.ToListAsync();
            ViewBag.Products = products;
            return View(products);
        }

        [HttpPost]
        public async Task<IActionResult> CreateExternalReceipt(string remarks, List<int> productIds, List<decimal> quantities)
        {
            if (productIds == null || productIds.Count == 0 || quantities == null || quantities.Count == 0)
            {
                ViewBag.Error = "Nale¿y wybraæ produkty i podaæ iloœci.";
                return View();
            }

            var userId = User.FindFirst(ClaimTypes.Sid)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("Nie mo¿na zidentyfikowaæ u¿ytkownika.");
            }

            var externalReceipt = new ExternalReceipt
            {
                Date = DateTime.UtcNow,
                Remarks = remarks,
                UserId = int.Parse(userId),
                Details = productIds.Select((productId, index) => new ExternalReceiptDetail
                {
                    ProductId = productId,
                    Quantity = quantities[index]
                }).ToList(),
            };

            _dbContext.ExternalReceipts.Add(externalReceipt);
            foreach (var detail in externalReceipt.Details)
            {
                var product = await _dbContext.Products.FindAsync(detail.ProductId);
                if (product != null)
                {
                    product.QuantityInStock -= detail.Quantity;
                }
            }

            await _dbContext.SaveChangesAsync();

            return RedirectToAction("ExternalReceipts");
        }

        public async Task<IActionResult> ExternalReceiptDetails(int id)
        {
            var externalReceipt = await _dbContext.ExternalReceipts.Include(i => i.User).Include(i => i.Details).ThenInclude(d => d.Product).FirstOrDefaultAsync(i => i.Id == id);

            return View(externalReceipt);
        }

        public async Task<IActionResult> InternalReceipts()
        {
            var internalReceipts = await _dbContext.InternalReceipts.Include(i => i.User).Include(i => i.Details).ToListAsync();
            return View(internalReceipts);
        }

        public async Task<IActionResult> CreateInternalReceipt()
        {
            var products = await _dbContext.Products.ToListAsync();
            ViewBag.Products = products;
            return View(products);
        }

        [HttpPost]
        public async Task<IActionResult> CreateInternalReceipt(string remarks, List<int> productIds, List<decimal> quantities)
        {
            if (productIds == null || productIds.Count == 0 || quantities == null || quantities.Count == 0)
            {
                ViewBag.Error = "Nale¿y wybraæ produkty i podaæ iloœci.";
                return View();
            }

            var userId = User.FindFirst(ClaimTypes.Sid)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("Nie mo¿na zidentyfikowaæ u¿ytkownika.");
            }

            var internalReceipt = new InternalReceipt
            {
                Date = DateTime.UtcNow,
                Remarks = remarks,
                UserId = int.Parse(userId),
                Details = productIds.Select((productId, index) => new InternalReceiptDetail
                {
                    ProductId = productId,
                    Quantity = quantities[index]
                }).ToList(),
            };

            _dbContext.InternalReceipts.Add(internalReceipt);
            foreach (var detail in internalReceipt.Details)
            {
                var product = await _dbContext.Products.FindAsync(detail.ProductId);
                if (product != null)
                {
                    product.QuantityInStock -= detail.Quantity;
                }
            }

            await _dbContext.SaveChangesAsync();

            return RedirectToAction("InternalReceipts");
        }

        public async Task<IActionResult> InternalReceiptDetails(int id)
        {
            var internalReceipt = await _dbContext.InternalReceipts.Include(i => i.User).Include(i => i.Details).ThenInclude(d => d.Product).FirstOrDefaultAsync(i => i.Id == id);

            return View(internalReceipt);
        }

        public async Task<IActionResult> Users()
        {
            var users = await _dbContext.Users.ToListAsync();
            return View(users);
        }

        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(string username, string password, string role)
        {
            if (username == null || password == null || role == null) { 
              ViewBag.Error = "Wszystkie pola s¹ wymagane.";
                return View();
            }

            if (_dbContext.Users.Any(u => u.Username == username))
            {
                ViewBag.Error = "U¿ytkownik o podanej nazwie ju¿ istnieje.";
                return View();
            }

            var user = new User
            {
                Username = username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(password),
                Role = role,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            _dbContext.Users.Add(user);

            await _dbContext.SaveChangesAsync();

            return RedirectToAction("Users");
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
