using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SoftShopDatabaseImplement.Models
{
    public class Warehouse
    {
        public int Id { get; set; }
        [Required]
        public string WarehouseName { get; set; }
        public virtual List<WarehouseSoft> WarehouseSofts { get; set; }
    }
}