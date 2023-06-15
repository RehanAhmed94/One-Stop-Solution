using System.ComponentModel.DataAnnotations;

namespace One_Stop_Solution.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        public int CategoryId { get; set; }
        
        public string? CategoryName { get; set; }
        public Guid ServiceId { get; set; }
        public string ServiceName { get; set; }
        public int ServicePrice { get; set; }

    }
}
