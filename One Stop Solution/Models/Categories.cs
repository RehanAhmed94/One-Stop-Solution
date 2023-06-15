using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace One_Stop_Solution.Models
{
    
    [Table("Categories")]
    public class Categories
    {

        [Key]
        public int CategoryId { get; set; }
        [Required]
        public string? CategoryName { get; set; }
        [NotMapped]
        public IFormFile Categorypic { get; set; }
        public byte[] Image { get; set; }

     
    }
}
