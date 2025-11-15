using DoAnLapTrinhWebBanThucAnNhanh.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAnLapTrinhWebBanThucAnNhanh.Models
{
    [Table("Roles")]
    public class Role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Mã vai trò")]
        public int RoleID { get; set; }

        [Required(ErrorMessage = "Tên vai trò không được để trống")]
        [StringLength(50, ErrorMessage = "Tên vai trò tối đa 50 ký tự")]
        [Display(Name = "Tên vai trò")]
        public string RoleName { get; set; } = string.Empty;

        // 1 Role có nhiều UserHL
        [Display(Name = "Danh sách người dùng")]
        public ICollection<UserHL> Users { get; set; } = new HashSet<UserHL>();
    }
}
