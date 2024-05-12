using System.ComponentModel.DataAnnotations;

namespace BTL_ClothesStore.ModelViews
{
    public class LoginViewModel
    {
        [MaxLength(100)]
        [Required(ErrorMessage = "Vui lòng nhập tên tài khoản")]
        [Display(Name = "Tài khoản")]
        public string UserAccount { get; set; }
        [MinLength(8, ErrorMessage = "Mật khẩu tối thiểu 8 kí tự")]
        [Required(ErrorMessage = "Vui lòng nhập tên tài khoản")]
        [Display(Name = "Tài khoản")]
        public string PassWord { get; set; }
    }
}
