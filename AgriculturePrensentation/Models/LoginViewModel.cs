using System.ComponentModel.DataAnnotations;

namespace AgriculturePrensentation.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Lütfen Kullanıcı Adını Giriniz!")]
        public string username { get; set; }

        [Required(ErrorMessage = "Lütfen Şifreyi Giriniz!")]
        public string password { get; set; }
    }
}
