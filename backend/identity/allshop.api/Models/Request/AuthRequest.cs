
using System.ComponentModel.DataAnnotations;
namespace allshop.Models.Request
{
    public class AuthRequest
    {
        [Required]
        public string Email { get; set; }
       
        [Required]
        [MinLength(4, ErrorMessage ="Su Contraseña debe ser mayo a 4 caracteres")]
        [MaxLength(10, ErrorMessage = "Su Contraseña debe ser menos a 10 caracteres")]
        public string Password { get; set; }

        public string Token { get; set;}
    }
}
