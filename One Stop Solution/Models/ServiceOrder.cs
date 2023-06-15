using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace One_Stop_Solution.Models
{
    
    public class ServiceOrder
    {
        [Key]
        public int OrderId { get; set; }

        public int OrdersTotal { get; set; }
        public Guid ServiceId { get; set; }
    }
}
