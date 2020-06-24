using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SoftShopDatabaseImplement.Models
{
    public class WarehouseSoft
    {
        public int Id { get; set; }
        public int WarehouseId { get; set; }
        public int SoftId { get; set; }
        [Required]
        public int Count { get; set; }
        public virtual Soft Soft { get; set; }
        public virtual Warehouse Warehouse { get; set; }
    }
}