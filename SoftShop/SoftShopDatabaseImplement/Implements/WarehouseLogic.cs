using Microsoft.EntityFrameworkCore;
using SoftShopBusinessLogic.BindingModels;
using SoftShopBusinessLogic.Interfaces;
using SoftShopBusinessLogic.ViewModels;
using SoftShopDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftShopDatabaseImplement.Implements
{
    public class WarehouseLogic : IWarehouseLogic
    {
        public List<WarehouseViewModel> GetList()
        {
            using (var context = new SoftShopDatabase())
            {
                return context.Warehouses
                .ToList()
               .Select(rec => new WarehouseViewModel
               {
                   Id = rec.Id,
                   WarehouseName = rec.WarehouseName,
                   WarehouseSofts = context.WarehouseSofts
                .Include(recWS => recWS.Soft)
               .Where(recWS => recWS.WarehouseId == rec.Id).
               Select(x => new WarehouseSoftViewModel
               {
                   Id = x.Id,
                   WarehouseId = x.WarehouseId,
                   SoftId = x.SoftId,
                   SoftName = context.Softs.FirstOrDefault(y => y.Id == x.SoftId).SoftName,
                   Count = x.Count
               })
               .ToList()
               })
            .ToList();
            }
        }
        public WarehouseViewModel GetElement(int id)
        {
            using (var context = new SoftShopDatabase())
            {
                var elem = context.Warehouses.FirstOrDefault(x => x.Id == id);
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
                        WarehouseSofts = context.WarehouseSofts
                .Include(recWS => recWS.Soft)
               .Where(recWS => recWS.WarehouseId == elem.Id)
                        .Select(x => new WarehouseSoftViewModel
                        {
                            Id = x.Id,
                            WarehouseId = x.WarehouseId,
                            SoftId = x.SoftId,
                            SoftName = context.Softs.FirstOrDefault(y => y.Id == x.SoftId).SoftName,
                            Count = x.Count
                        }).ToList()
                    };
                }
            }
        }
        public void AddElement(WarehouseBindingModel model)
        {
            using (var context = new SoftShopDatabase())
            {
                var elem = context.Warehouses.FirstOrDefault(x => x.WarehouseName == model.WarehouseName);
                if (elem != null)
                {
                    throw new Exception("Уже есть склад с таким названием");
                }
                var warehouse = new Warehouse();
                context.Warehouses.Add(warehouse);
                warehouse.WarehouseName = model.WarehouseName;
                context.SaveChanges();
            }
        }
        public void UpdElement(WarehouseBindingModel model)
        {
            using (var context = new SoftShopDatabase())
            {
                var elem = context.Warehouses.FirstOrDefault(x => x.WarehouseName == model.WarehouseName && x.Id != model.Id);
                if (elem != null)
                {
                    throw new Exception("Уже есть склад с таким названием");
                }
                var elemToUpdate = context.Warehouses.FirstOrDefault(x => x.Id == model.Id);
                if (elemToUpdate != null)
                {
                    elemToUpdate.WarehouseName = model.WarehouseName;
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        public void DelElement(int id)
        {
            using (var context = new SoftShopDatabase())
            {
                var elem = context.Warehouses.FirstOrDefault(x => x.Id == id);
                if (elem != null)
                {
                    context.Warehouses.Remove(elem);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        public void FillWarehouse(WarehouseSoftBindingModel model)
        {
            using (var context = new SoftShopDatabase())
            {
                var item = context.WarehouseSofts.FirstOrDefault(x => x.SoftId == model.SoftId
    && x.WarehouseId == model.WarehouseId);

                if (item != null)
                {
                    item.Count += model.Count;
                }
                else
                {
                    var elem = new WarehouseSoft();
                    context.WarehouseSofts.Add(elem);
                    elem.WarehouseId = model.WarehouseId;
                    elem.SoftId = model.SoftId;
                    elem.Count = model.Count;
                }
                context.SaveChanges();
            }
        }
        public void RemoveFromWarehouse(int packId, int packsCount)
        {
            using (var context = new SoftShopDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var packSofts = context.PackSofts.Where(x => x.PackId == packId);
                        if (packSofts.Count() == 0) return;
                        foreach (var elem in packSofts)
                        {
                            int left = elem.Count * packsCount;
                            var WarehouseSofts = context.WarehouseSofts.Where(x => x.SoftId == elem.SoftId);
                            int available = WarehouseSofts.Sum(x => x.Count);
                            if (available < left) throw new Exception("Недостаточно ПО на складе");
                            foreach (var rec in WarehouseSofts)
                            {
                                int toRemove = left > rec.Count ? rec.Count : left;
                                rec.Count -= toRemove;
                                left -= toRemove;
                                if (left == 0) break;
                            }
                        }
                        context.SaveChanges();
                        transaction.Commit();
                        return;
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}