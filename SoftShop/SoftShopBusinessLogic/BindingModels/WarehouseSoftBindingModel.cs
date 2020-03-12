using System;
using System.Collections.Generic;
using System.Text;

namespace SoftShopBusinessLogic.BindingModels
{
    public class WarehouseSoftBindingModel
    {
        public int Id { get; set; }
        public int StorageId { get; set; }
        public int FlowerId { get; set; }
        public int Count { get; set; }
    }
}
