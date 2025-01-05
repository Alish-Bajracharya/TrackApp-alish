using System.ComponentModel.DataAnnotations;

namespace TrackApp_alish.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Currency is required")]
        public string Currency { get; set; }
    }
}
