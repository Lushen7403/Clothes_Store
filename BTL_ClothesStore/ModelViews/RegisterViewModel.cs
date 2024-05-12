using System.ComponentModel.DataAnnotations;

namespace BTL_ClothesStore.ModelViews
{
    public class RegisterViewModel
    {
       
        public string UserName { get; set; } = null!;
        
        public string UserAccount { get; set; } = null!;
        
        public string? UserEmail { get; set; }
        
        public string UserPassword { get; set; } = null!;
        [Required(ErrorMessage = "Hãy nhập mật khẩu")]
        [MinLength(8, ErrorMessage = "Mật khẩu phải có ít nhất 8 ký tự")]
        public string ConfirmPassword { get; set; }


        
        public string? UserAddress { get; set; }
       
        public string? UserPhone { get; set; }



    }
}
