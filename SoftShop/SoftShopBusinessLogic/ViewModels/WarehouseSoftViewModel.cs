using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SoftShopBusinessLogic.ViewModels
{
    public class WarehouseSoftViewModel
    {
        public int Id { get; set; }
        public int WarehouseId { get; set; }
        public int SoftId { get; set; }
        [DisplayName("Название склада")]
        public string WarehouseName { get; set; }
        [DisplayName("Название ПО")]
        public string SoftName { get; set; }
        [DisplayName("Количество")]
        public int Count { get; set; }
    }
}