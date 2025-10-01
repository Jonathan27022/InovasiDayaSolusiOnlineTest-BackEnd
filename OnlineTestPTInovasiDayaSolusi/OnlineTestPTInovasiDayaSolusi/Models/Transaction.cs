using System.ComponentModel.DataAnnotations;

namespace OnlineTestPTInovasiDayaSolusi.Models
{
    public class Transaction
    {
        [Key]
        public int id { get; set; }
        public string? productID { get; set; }
        public string? productName { get; set; }
        public int amount { get; set; }
        public string? customerName { get; set; }
        public int status { get; set; }
        public DateTime transactionDate { get; set; }
        public string? createBy { get; set; }
        public DateTime createOn { get; set; }
    }
}
