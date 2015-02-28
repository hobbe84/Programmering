using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Slumpade_Kontakter_A.Models
{
    public class Contact
    {
        [DisplayName("Email")]
        [Required(ErrorMessage = "Du måste ange en email")]
        [RegularExpression(".+\\@.+\\..+",
            ErrorMessage = "Du måste ange en giltig email")]
        [StringLength(50,MinimumLength = 6, ErrorMessage = "Email måste innehålla mer än 3 tecken")]
        public string Email{ get; set; }

        [DisplayName("Förnamn")]
        [Required(ErrorMessage = "Du måste ange ett förnamn.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Namnet måste vara minst 3 tecken")]
        public string FirstName { get; set; }

        [Key]
        public Guid Id { get; set; }

        [DisplayName("Efternamn")]
        [Required(ErrorMessage = "Du måste ange ett efternamn.")]
        [StringLength (50, MinimumLength= 3, ErrorMessage = "Efternamnet måste innehålla minst 3 tecken")]
        public string LastName { get; set; }

        [DisplayFormat(DataFormatString="{0:d}")]
        public DateTime Date { get; set; }

        // Konstruktor
        public Contact()
        {
            Id = Guid.NewGuid();
            Date = DateTime.Now;
            
        }
       

    }
}