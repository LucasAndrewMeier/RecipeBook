using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace RecipeBook.Domain.Entities
{
    public class Profile
    {
        [HiddenInput(DisplayValue = false)]
        public int ProfileID { get; set; }

        [Required(ErrorMessage ="Please enter a user name")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Please enter a valid password")]
        public string Password { get; set; }

        [Required(ErrorMessage ="Please enter your first name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage ="Please enter your last name")]
        public string LastName { get; set; }
        [Required(ErrorMessage ="Please enter a valid email address")]
        public string Email { get; set; }

    }
}
