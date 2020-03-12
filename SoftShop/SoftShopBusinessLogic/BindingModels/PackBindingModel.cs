using System;
using System.Collections.Generic;
using System.Text;

namespace SoftShopBusinessLogic.BindingModels
{
    public class PackBindingModel
    {
        public int? Id { get; set; }
        public string PackName { get; set; }
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> PackSofts { get; set; }
    }
}