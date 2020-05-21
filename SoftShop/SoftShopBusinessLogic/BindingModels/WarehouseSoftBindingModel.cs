using System;
using System.Collections.Generic;
using System.Text;

namespace SoftShopBusinessLogic.BindingModels
{
    public class WarehouseSoftBindingModel
    {
        public int Id { get; set; }
        public int WarehouseId { get; set; }
        public int SoftId { get; set; }
        public int Count { get; set; }
    }
}
