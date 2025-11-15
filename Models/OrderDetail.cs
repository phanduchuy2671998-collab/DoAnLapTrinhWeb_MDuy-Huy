using DoAnLapTrinhWebBanThucAnNhanh.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAnLapTrinhWebBanThucAnNhanh.Models
{
    [Table("OrderDetails")]
    public class OrderDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderDetailID { get; set; }

        // FK đến CustomerOrder
        [Required]
        public int CustomerOrderID { get; set; }

        [ForeignKey(nameof(CustomerOrderID))]
        public virtual CustomerOrder? CustomerOrder { get; set; }

        // FK đến Product
        [Required]
        public int ProductID { get; set; }

        [ForeignKey(nameof(ProductID))]
        public virtual Product? Product { get; set; }

        // Số lượng
        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        // Giá trên 1 sản phẩm
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        // Tổng dòng = Quantity * Price
        [NotMapped]
        public decimal LineTotal => Quantity * Price;
    }
}
