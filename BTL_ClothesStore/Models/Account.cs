using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BTL_ClothesStore.Models;

public partial class Account
{
    public int AccountId { get; set; }
    [Required(ErrorMessage = "Hãy nhập tên người dùng")]
    public string UserName { get; set; } = null!;
    [Required(ErrorMessage = "Hãy nhập Tên đăng nhập")]
    public string UserAccount { get; set; } = null!;
    [Required(ErrorMessage = "Email bắt buộc phải được nhập")]
    [EmailAddress(ErrorMessage = "Địa chỉ email không hợp lệ")]
    [RegularExpression(@"^.+@gmail\.com$", ErrorMessage = "Email phải có đuôi gmail.com")]
    public string? UserEmail { get; set; }
    [Required(ErrorMessage = "Hãy nhập mật khẩu")]
    [MinLength(8, ErrorMessage = "Mật khẩu phải có ít nhất 8 ký tự")]
    public string UserPassword { get; set; } = null!;
    [Required(ErrorMessage = "Hãy nhập địa chỉ")]
    public string? UserAddress { get; set; }
    [Required(ErrorMessage = "Hãy nhập Số điện thoại")]
    public string? UserPhone { get; set; }

    public int? RoleId { get; set; }

    public virtual ICollection<FeedBack> FeedBacks { get; set; } = new List<FeedBack>();

    public virtual ICollection<OrderTable> OrderTables { get; set; } = new List<OrderTable>();

    public virtual Role? Role { get; set; }
}
