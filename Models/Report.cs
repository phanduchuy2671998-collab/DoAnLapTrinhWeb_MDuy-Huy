using DoAnLapTrinhWebBanThucAnNhanh.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAnLapTrinhWebBanThucAnNhanh.Models
{
    [Table("Reports")]
    public class Report
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Mã báo cáo")]
        public int ReportID { get; set; }

        [Display(Name = "Ngày báo cáo")]
        public DateTime ReportDate { get; set; } = DateTime.UtcNow;

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Tổng số đơn phải >= 0")]
        [Display(Name = "Tổng số đơn hàng")]
        public int TotalOrders { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        [Range(0, double.MaxValue, ErrorMessage = "Doanh thu không được âm")]
        [Display(Name = "Tổng doanh thu (VNĐ)")]
        public decimal TotalRevenue { get; set; }

        // FK → UserHL
        [Required(ErrorMessage = "Người tạo không được để trống")]
        [Display(Name = "Mã người tạo báo cáo")]
        public int CreatedBy { get; set; }

        [ForeignKey(nameof(CreatedBy))]
        [Display(Name = "Tài khoản người tạo")]
        public UserHL? User { get; set; }
    }
}
