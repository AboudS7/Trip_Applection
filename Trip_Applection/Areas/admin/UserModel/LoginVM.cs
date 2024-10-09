using System.ComponentModel.DataAnnotations;

namespace Trip_Applection.Areas.admin.UserModel
{
    public class LoginVM
    {
        [Required(ErrorMessage = "يجب ادخال اسم المستخدم")]
        public string Username { get; set; } = null!;
        [Required(ErrorMessage = "يجب ادخال كلمة السر")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}
