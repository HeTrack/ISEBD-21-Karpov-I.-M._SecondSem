using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SoftShopDatabaseImplement.Models
{
    public class Soft
    {
        public int Id { get; set; }
        [Required]  
        public string SoftName { get; set; }
        [ForeignKey("SoftId")]
        public virtual List<PackSoft> PackSofts { get; set; }
    }
}