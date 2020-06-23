using SoftShopBusinessLogic.BindingModels;
using SoftShopBusinessLogic.Interfaces;
using SoftShopBusinessLogic.ViewModels;
using SoftShopListImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftShopListImplement.Implements
{
    public class WarehouseLogic : IWarehouseLogic
    {
        private readonly DataListSingleton source;
        public WarehouseLogic()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<WarehouseViewModel> GetList()
        {
            List<WarehouseViewModel> result = new List<WarehouseViewModel>();
            for (int i = 0; i < source.Warehouses.Count; ++i)
            {
                List<WarehouseSoftViewModel> WarehouseSofts = new
    List<WarehouseSoftViewModel>();
                for (int j = 0; j < source.WarehouseSofts.Count; ++j)
                {
                    if (source.WarehouseSofts[j].WarehouseId == source.Warehouses[i].Id)
                    {
                        string SoftName = string.Empty;
                        for (int k = 0; k < source.Softs.Count; ++k)
                        {
                            if (source.WarehouseSofts[j].SoftId ==
                           source.Softs[k].Id)
                            {
                                SoftName = source.Softs[k].SoftName;
                                break;
                            }
                        }
                        WarehouseSofts.Add(new WarehouseSoftViewModel
                        {
                            Id = source.WarehouseSofts[j].Id,
                            WarehouseId = source.WarehouseSofts[j].WarehouseId,
                            SoftId = source.WarehouseSofts[j].SoftId,
                            SoftName = SoftName,
                            Count = source.WarehouseSofts[j].Count
                        });
                    }
                }
                result.Add(new WarehouseViewModel
                {
                    Id = source.Warehouses[i].Id,
                    WarehouseName = source.Warehouses[i].WarehouseName,
                    WarehouseSofts = WarehouseSofts
                });
            }
            return result;
        }
        public WarehouseViewModel GetElement(int id)
        {
            for (int i = 0; i < source.Warehouses.Count; ++i)
            {
                List<WarehouseSoftViewModel> WarehouseSofts = new
    List<WarehouseSoftViewModel>();
                for (int j = 0; j < source.WarehouseSofts.Count; ++j)
                {
                    if (source.WarehouseSofts[j].WarehouseId == source.Warehouses[i].Id)
                    {
                        string SoftName = string.Empty;
                        for (int k = 0; k < source.Softs.Count; ++k)
                        {
                            if (source.WarehouseSofts[j].SoftId ==
                           source.Softs[k].Id)
                            {
                                SoftName = source.Softs[k].SoftName;
                                break;
                            }
                        }
                        WarehouseSofts.Add(new WarehouseSoftViewModel
                        {
                            Id = source.WarehouseSofts[j].Id,
                            WarehouseId = source.WarehouseSofts[j].WarehouseId,
                            SoftId = source.WarehouseSofts[j].SoftId,
                            SoftName = SoftName,
                            Count = source.WarehouseSofts[j].Count
                        });
                    }
                }
                if (source.Warehouses[i].Id == id)
                {
                    return new WarehouseViewModel
                    {
                        Id = source.Warehouses[i].Id,
                        WarehouseName = source.Warehouses[i].WarehouseName,
                        WarehouseSofts = WarehouseSofts
                    };
                }
            }
            throw new Exception("Элемент не найден");
        }
        public void AddElement(WarehouseBindingModel model)
        {
            int maxId = 0;
            for (int i = 0; i < source.Warehouses.Count; ++i)
            {
                if (source.Warehouses[i].Id > maxId)
                {
                    maxId = source.Warehouses[i].Id;
                }
                if (source.Warehouses[i].WarehouseName == model.WarehouseName)
                {
                    throw new Exception("Уже есть склад с таким названием");
                }
            }
            source.Warehouses.Add(new Warehouse
            {
                Id = maxId + 1,
                WarehouseName = model.WarehouseName
            });
        }
        public void UpdElement(WarehouseBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.Warehouses.Count; ++i)
            {
                if (source.Warehouses[i].Id == model.Id)
                {
                    index = i;
                }
                if (source.Warehouses[i].WarehouseName == model.WarehouseName &&
                source.Warehouses[i].Id != model.Id)
                {
                    throw new Exception("Уже есть склад с таким названием");
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            source.Warehouses[index].WarehouseName = model.WarehouseName;
        }
        public void DelElement(WarehouseBindingModel model)
        {
            for (int i = 0; i < source.WarehouseSofts.Count; ++i)
            {
                if (source.WarehouseSofts[i].WarehouseId == model.Id)
                {
                    source.WarehouseSofts.RemoveAt(i--);
                }
            }
            for (int i = 0; i < source.Warehouses.Count; ++i)
            {
                if (source.Warehouses[i].Id == model.Id)
                {
                    source.Warehouses.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
        public bool CheckSoftsAvailability(int PackId, int PacksCount)
        {
            bool result = true;
            var PackSofts = source.PackSofts.Where(x => x.PackId == PackId);
            if (PackSofts.Count() == 0) return false;
            foreach (var elem in PackSofts)
            {
                int count = 0;
                count = source.WarehouseSofts.FindAll(x => x.SoftId == elem.SoftId).Sum(x => x.Count);
                if (count < elem.Count * PacksCount)
                    return false;
            }
            return result;
        }
        public void RemoveFromWarehouse(int PackId, int PacksCount)
        {
            var PackSofts = source.PackSofts.Where(x => x.PackId == PackId);
            if (PackSofts.Count() == 0) return;
            foreach (var elem in PackSofts)
            {
                int left = elem.Count * PacksCount;
                var warehouseSofts = source.WarehouseSofts.FindAll(x => x.SoftId == elem.SoftId);
                foreach (var rec in warehouseSofts)
                {
                    int toRemove = left > rec.Count ? rec.Count : left;
                    rec.Count -= toRemove;
                    left -= toRemove;
                    if (left == 0) break;
                }
            }
            return;
        }
        public void FillWarehouse(WarehouseSoftBindingModel model)
        {
            int foundItemIndex = -1;
            for (int i = 0; i < source.WarehouseSofts.Count; ++i)
            {
                if (source.WarehouseSofts[i].SoftId == model.SoftId
                    && source.WarehouseSofts[i].WarehouseId == model.WarehouseId)
                {
                    foundItemIndex = i;
                    break;
                }
            }
            if (foundItemIndex != -1)
            {
                source.WarehouseSofts[foundItemIndex].Count =
                    source.WarehouseSofts[foundItemIndex].Count + model.Count;
            }
            else
            {
                int maxId = 0;
                for (int i = 0; i < source.WarehouseSofts.Count; ++i)
                {
                    if (source.WarehouseSofts[i].Id > maxId)
                    {
                        maxId = source.WarehouseSofts[i].Id;
                    }
                }
                source.WarehouseSofts.Add(new WarehouseSoft
                {
                    Id = maxId + 1,
                    WarehouseId = model.WarehouseId,
                    SoftId = model.SoftId,
                    Count = model.Count
                });
            }
        }
    }
}