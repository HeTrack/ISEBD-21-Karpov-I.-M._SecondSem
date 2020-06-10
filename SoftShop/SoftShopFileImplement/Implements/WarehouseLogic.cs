using SoftShopBusinessLogic.BindingModels;
using SoftShopBusinessLogic.Interfaces;
using SoftShopBusinessLogic.ViewModels;
using SoftShopFileImplement.Models;
using SoftShopFileImplement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftShopFileImplement.Implements
{
   public class WarehouseLogic: IWarehouseLogic
    { 
   private readonly FileDataListSingleton source;
    public WarehouseLogic()
    {
        source = FileDataListSingleton.GetInstance();
    }
    public List<WarehouseViewModel> GetList()
    {
        return source.Warehouses.Select(rec => new WarehouseViewModel
        {
            Id = rec.Id,
            WarehouseName = rec.WarehouseName,
            WarehouseSofts = source.WarehouseSofts.Where(z => z.WarehouseId == rec.Id).Select(x => new WarehouseSoftViewModel
            {
                Id = x.Id,
                WarehouseId = x.WarehouseId,
                SoftId = x.SoftId,
                SoftName = source.Softs.FirstOrDefault(y => y.Id == x.SoftId)?.SoftName,
                Count = x.Count
            }).ToList()
        })
            .ToList();
    }
    public WarehouseViewModel GetElement(int id)
    {
        var elem = source.Warehouses.FirstOrDefault(x => x.Id == id);
        if (elem == null)
        {
            throw new Exception("Элемент не найден");
        }
        else
        {
            return new WarehouseViewModel
            {
                Id = id,
                WarehouseName = elem.WarehouseName,
                WarehouseSofts = source.WarehouseSofts.Where(z => z.WarehouseId == elem.Id).Select(x => new WarehouseSoftViewModel
                {
                    Id = x.Id,
                    WarehouseId = x.WarehouseId,
                    SoftId = x.SoftId,
                    SoftName = source.Softs.FirstOrDefault(y => y.Id == x.SoftId)?.SoftName,
                    Count = x.Count
                }).ToList()
            };
        }
    }

    public void AddElement(WarehouseBindingModel model)
    {

        var elem = source.Warehouses.FirstOrDefault(x => x.WarehouseName == model.WarehouseName);
        if (elem != null)
        {
            throw new Exception("Уже есть склад с таким названием");
        }
        int maxId = source.Warehouses.Count > 0 ? source.Warehouses.Max(rec => rec.Id) : 0;
        source.Warehouses.Add(new Warehouse
        {
            Id = maxId + 1,
            WarehouseName = model.WarehouseName
        });
    }
    public void UpdElement(WarehouseBindingModel model)
    {
        var elem = source.Warehouses.FirstOrDefault(x => x.WarehouseName == model.WarehouseName && x.Id != model.Id);
        if (elem != null)
        {
            throw new Exception("Уже есть склад с таким названием");
        }
        var elemToUpdate = source.Warehouses.FirstOrDefault(x => x.Id == model.Id);
        if (elemToUpdate != null)
        {
            elemToUpdate.WarehouseName = model.WarehouseName;
        }
        else
        {
            throw new Exception("Элемент не найден");
        }
    }
    public void DelElement(int id)
    {
        var elem = source.Warehouses.FirstOrDefault(x => x.Id == id);
        if (elem != null)
        {
            source.Warehouses.Remove(elem);
        }
        else
        {
            throw new Exception("Элемент не найден");
        }
    }

    public void FillWarehouse(WarehouseSoftBindingModel model)
    {
        var item = source.WarehouseSofts.FirstOrDefault(x => x.SoftId == model.SoftId
                && x.WarehouseId == model.WarehouseId);

        if (item != null)
        {
            item.Count += model.Count;
        }
        else
        {
            int maxId = source.WarehouseSofts.Count > 0 ? source.WarehouseSofts.Max(rec => rec.Id) : 0;
            source.WarehouseSofts.Add(new WarehouseSoft
            {
                Id = maxId + 1,
                WarehouseId = model.WarehouseId,
                SoftId = model.SoftId,
                Count = model.Count
            });
        }
    }

    public bool CheckSoftsAvailability(int PackId, int PacksCount)
    {
        bool result = true;
        var PackSofts = source.PackSofts.Where(x => x.PackId == PackId);
        if (PackSofts.Count() == 0) return false;
        foreach (var elem in PackSofts)
        {
            int count = 0;
            var storageSofts = source.WarehouseSofts.FindAll(x => x.SoftId == elem.SoftId);
                count = storageSofts.Sum(x => x.Count);
                if (count < elem.Count * PacksCount) 
                    result = false;
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
            var storageSofts = source.WarehouseSofts.FindAll(x => x.SoftId == elem.SoftId);
            foreach (var rec in storageSofts)
            {
                int toRemove = left > rec.Count ? rec.Count : left;
                rec.Count -= toRemove;
                left -= toRemove;
                if (left == 0) break;
            }
        }
        return;
    }
}
} 