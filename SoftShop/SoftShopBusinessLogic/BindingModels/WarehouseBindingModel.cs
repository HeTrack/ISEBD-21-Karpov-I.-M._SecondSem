using System;
using System.Collections.Generic;
using System.Text;

namespace SoftShopBusinessLogic.BindingModels
{
    public class WarehouseBindingModel
    {
        public int? Id { get; set; }
        public string WarehouseName { get; set; }
        public List<WarehouseSoftBindingModel> WarehouseSofts { get; set; }
    }
}
