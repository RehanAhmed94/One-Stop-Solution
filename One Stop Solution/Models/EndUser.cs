using Org.BouncyCastle.Math;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace One_Stop_Solution.Models
{
    
    [Table("EndUser")]
    public class EndUser
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public string? Username { get; set; }
        [Required]
        public int? Age { get; set; }
        [Required]
        public string?  Contact { get; set; }
        [Required]
        public string? PostalAddress { get; set; }
    }
}
