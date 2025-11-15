using DoAnLapTrinhWebBanThucAnNhanh.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAnLapTrinhWebBanThucAnNhanh.Models
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryID { get; set; }   // Tự tăng trong DB

        [Required(ErrorMessage = "Tên danh mục không được để trống")]
        [StringLength(50, ErrorMessage = "Tên danh mục tối đa 50 ký tự")]
        public string CategoryName { get; set; } = string.Empty;

        // (Tuỳ chọn) thêm cờ kích hoạt
        // public bool IsActive { get; set; } = true;

        // Navigation: 1 Category có nhiều Product
        public ICollection<Product>? Products { get; set; }
    }
}
