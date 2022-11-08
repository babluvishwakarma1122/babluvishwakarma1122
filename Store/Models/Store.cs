using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Store
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Mbrand { get; set; }
        public decimal SalePrice { get; set; }
        public decimal PurchPrice { get; set; }
        public int pro_loss { get; set; }
        public decimal Discount { get; set; }
        public DateTime Dates { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
