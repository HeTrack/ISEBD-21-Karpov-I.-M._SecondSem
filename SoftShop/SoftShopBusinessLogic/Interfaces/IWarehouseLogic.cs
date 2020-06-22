using SoftShopBusinessLogic.BindingModels;
using SoftShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftShopBusinessLogic.Interfaces
{
    public interface IWarehouseLogic
    {
        List<WarehouseViewModel> GetList();
        WarehouseViewModel GetElement(int id);
        void AddElement(WarehouseBindingModel model);
        void UpdElement(WarehouseBindingModel model);
        void DelElement(int id);
        void FillWarehouse(WarehouseSoftBindingModel model);  
        void RemoveFromWarehouse(int packId, int packsCount);
    }
}