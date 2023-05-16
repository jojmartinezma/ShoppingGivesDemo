using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace testApiInterview1.Models
{

    [Table("Contacts")]
    public class Contactcs
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string? Email { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }
}
