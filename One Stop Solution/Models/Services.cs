using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace One_Stop_Solution.Models
{
       
    [Table("Services")]
    public class Services
    {
        [Key]
        public Guid ServiceId { get; set; }
        public int CategoryId { get; set; }
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }
        public int ServicePrice { get; set; }

        [NotMapped]
        public IFormFile Servicepic { get; set; }
        public byte[] ServiceImage { get; set; }
     

    }
}
