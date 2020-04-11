using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SoftShopDatabaseImplement.Models
{
    public class Pack
    {
        public int Id { get; set; }
        [Required]
        public string PackName { get; set; }
        [ForeignKey("PackId")]
        [Required]
        public decimal Price { get; set; }
        public virtual List<Order> Orders { get; set; }
        public virtual List<PackSoft> PackSofts { get; set; }
    }
}