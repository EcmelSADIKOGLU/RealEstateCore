using System.ComponentModel.DataAnnotations;

namespace RealEstate.PresentationLayer.Models
{
    public class UserLoginViewModel
    {
        [Required(ErrorMessage = "kullanıcı adı boş geçilemez")]
        public string username { get; set; }



        [Required(ErrorMessage = "şifre boş geçilemez")]
        public string password { get; set; }
    }
}
