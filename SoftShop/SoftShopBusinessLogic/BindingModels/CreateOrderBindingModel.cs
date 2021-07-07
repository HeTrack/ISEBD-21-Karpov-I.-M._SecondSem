using System;
using System.Collections.Generic;
using System.Text;

namespace SoftShopBusinessLogic.BindingModels
{
    public class CreateOrderBindingModel
    {
        public int PackId { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
    }
}