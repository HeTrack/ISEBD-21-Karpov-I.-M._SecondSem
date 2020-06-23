using SoftShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftShopRestApi.Models
{
    public class WarehouseModel
    {
        public int Id { get; set; }
        public string WarehouseName { get; set; }
        public List<WarehouseSoftViewModel> WarehouseSofts { get; set; }
    }
}
