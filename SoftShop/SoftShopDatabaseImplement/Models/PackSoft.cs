using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SoftShopDatabaseImplement.Models
{
    public class PackSoft
    {
        public int Id { get; set; }
        public int PackId { get; set; }
        public int SoftId { get; set; }
        [Required]
        public int Count { get; set; }
        public virtual Soft Soft { get; set; }
        public virtual Pack Pack { get; set; }
    }
}