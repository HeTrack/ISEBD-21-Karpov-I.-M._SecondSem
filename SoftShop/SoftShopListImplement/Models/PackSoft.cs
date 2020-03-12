using System;
using System.Collections.Generic;
using System.Text;

namespace SoftShopListImplement.Models
{
    public class PackSoft
    {
        public int Id { get; set; }
        public int PackId { get; set; }
        public int SoftId { get; set; }
        public int Count { get; set; }
    }
}