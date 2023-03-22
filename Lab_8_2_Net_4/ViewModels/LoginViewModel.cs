using System.ComponentModel.DataAnnotations;

namespace Lab_8_2_Net_4.ViewModel
{

    public class LoginViewModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

}
