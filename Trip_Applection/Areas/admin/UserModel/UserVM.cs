using System.ComponentModel.DataAnnotations;

namespace Trip_Applection.Areas.admin.UserModel
{
    public class UserVM
    {
        [Required(ErrorMessage = "يجب ادخال  الاميل")]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "يجب ادخال اسم المستخدم")]
        public string Username { get; set; } = null!;
        [Required(ErrorMessage = "يجب ادخال كلمة السر")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "كلمة المرور غير متطابقة")]
        public string ConferdPassword { get; set; } = null!;
        [Required(ErrorMessage = "يجب ادخال رقم الهاتف")]
        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;
        public string? FirestName { get; set;}
        public string? LastName { get; set;}
       
    }
}
