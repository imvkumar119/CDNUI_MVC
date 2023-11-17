using System.ComponentModel.DataAnnotations;

namespace CDN_UI.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        [Required]
        public string userName { get; set; }
        [Required]
        public string mail { get; set; }
        [Required]
        public string phoneNumber { get; set; }
        [Required]
        public string skillSet { get; set; }
        [Required]
        public string hobby { get; set; }

    }
}
