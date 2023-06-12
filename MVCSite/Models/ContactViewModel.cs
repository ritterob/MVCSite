using System.ComponentModel.DataAnnotations;

namespace MVCSite.Models {
    public class ContactViewModel {

        [Required(ErrorMessage = "* Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "* Required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "* Required")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "* Required")]
        public string Message { get; set; }

    }   // end class ContactViewModel
}
