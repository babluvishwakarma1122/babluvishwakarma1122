using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Sales
    {
       
        public DateTime fromDate { get; set; }
        public DateTime endDate { get; set; }
    }

    public class FillterBrand
    {
        public string brand { get; set; }
        public DateTime fromDate { get; set; }
        public DateTime endDate { get; set; }
    }

    public class ProfitLoss
    {
        public string Name { get; set; }
        public string Mbrand { get; set; }
        public decimal Loss { get; set; }
        public decimal Profit { get; set; }
        public decimal Discount { get; set; }
        
    }
}
