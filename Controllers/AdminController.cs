using Microsoft.AspNetCore.Mvc;
using DoAnLapTrinhWebBanThucAnNhanh.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DoAnLapTrinhWebBanThucAnNhanh.Controllers
{
    public class AdminController : Controller
    {
        private readonly FastFoodDbContext _context;

        public AdminController(FastFoodDbContext context)
        {
            _context = context;
        }

        // Dashboard tổng quan
        public IActionResult Dashboard()
        {
            // Có thể gửi số liệu thống kê: tổng sản phẩm, đơn hàng, doanh thu
            ViewBag.TotalProducts = _context.Products.Count();
            ViewBag.TotalOrders = _context.Orders.Count();
            ViewBag.TotalUsers = _context.Users.Count();
            return View();
        }

        // Quản lý sản phẩm
        public async Task<IActionResult> Products()
        {
            var products = await _context.Products.Include(p => p.Category).ToListAsync();
            return View(products);
        }

        // Quản lý danh mục
        public async Task<IActionResult> Categories()
        {
            var categories = await _context.Categories.ToListAsync();
            return View(categories);
        }

        // Quản lý đơn hàng
        public async Task<IActionResult> Orders()
        {
            var orders = await _context.Orders
                                       .Include(o => o.User)
                                       .Include(o => o.OrderDetails)
                                       .ThenInclude(d => d.Product)
                                       .ToListAsync();
            return View(orders);
        }

        // Báo cáo doanh thu
        public async Task<IActionResult> Reports()
        {
            var revenue = await _context.Orders
                                        .Where(o => o.Status == "Đã giao")
                                        .SumAsync(o => o.TotalPrice);
            ViewBag.TotalRevenue = revenue;
            return View(reports);
        }

        // Quản lý người dùng
        public async Task<IActionResult> Users()
        {
            var users = await _context.Users.ToListAsync();
            return View(users);
        }

        // Liên hệ khách hàng
        public async Task<IActionResult> Contacts()
        {
            var contacts = await _context.Contacts.ToListAsync();
            return View(contacts);
        }
    }
}
