using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace SoftShopBusinessLogic.ViewModels
{
    public class PackViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название пакета")]
        public string PackName { get; set; }
        [DisplayName("Цена")]
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> PackSofts { get; set; }
    }
}