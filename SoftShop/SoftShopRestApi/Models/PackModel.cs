using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftShopRestApi.Models
{
    public class PackModel
    {
        public int Id { get; set; }
        public string PackName { get; set; }
        public decimal Price { get; set; }
    }
}
