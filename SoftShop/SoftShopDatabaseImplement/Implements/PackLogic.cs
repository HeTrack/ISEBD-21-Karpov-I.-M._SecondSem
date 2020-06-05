using SoftShopBusinessLogic.BindingModels;
using SoftShopBusinessLogic.Interfaces;
using SoftShopBusinessLogic.ViewModels;
using SoftShopDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftShopDatabaseImplement.Implements
{
    public class PackLogic : IPackLogic
    {
        public void CreateOrUpdate(PackBindingModel model)
        {
            using (var context = new SoftShopDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Pack element = context.Packs.FirstOrDefault(rec =>
                        rec.PackName == model.PackName && rec.Id != model.Id);
                        if (element != null)
                        {
                            throw new Exception("Уже есть пакет с таким названием");
                        }
                        if (model.Id.HasValue)
                        {
                            element = context.Packs.FirstOrDefault(rec => rec.Id ==
                            model.Id);
                            if (element == null)
                            {
                                throw new Exception("Элемент не найден");
                            }
                        }
                        else
                        {
                            element = new Pack();
                            context.Packs.Add(element);
                        }
                        element.PackName = model.PackName;
                        element.Price = model.Price;
                        context.SaveChanges();
                        if (model.Id.HasValue)
                        {
                            var productComponents = context.PackSofts.Where(rec
                            => rec.PackId == model.Id.Value).ToList();
                            // удалили те, которых нет в модели
                            context.PackSofts.RemoveRange(productComponents.Where(rec =>
                            !model.PackSofts.ContainsKey(rec.SoftId)).ToList());
                            context.SaveChanges();
                            // обновили количество у существующих записей
                            foreach (var updateComponent in productComponents)
                            {
                                updateComponent.Count =
                                model.PackSofts[updateComponent.SoftId].Item2;

                                model.PackSofts.Remove(updateComponent.SoftId);
                            }
                            context.SaveChanges();
                        }
                        // добавили новые
                        foreach (var pc in model.PackSofts)
                        {
                            context.PackSofts.Add(new PackSoft
                            {
                                PackId = element.Id,
                                SoftId = pc.Key,
                                Count = pc.Value.Item2
                            });
                            context.SaveChanges();
                        }
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        public void Delete(PackBindingModel model)
        {
            using (var context = new SoftShopDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.PackSofts.RemoveRange(context.PackSofts.Where(rec =>
                        rec.PackId == model.Id));
                        Pack element = context.Packs.FirstOrDefault(rec => rec.Id
                        == model.Id);
                        if (element != null)
                        {
                            context.Packs.Remove(element);
                            context.SaveChanges();
                        }
                        else
                        {
                            throw new Exception("Элемент не найден");
                        }
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        public List<PackViewModel> Read(PackBindingModel model)
        {
            using (var context = new SoftShopDatabase())
            {
                return context.Packs
                .Where(rec => model == null || rec.Id == model.Id)
                .ToList()
                .Select(rec => new PackViewModel
                {
                    Id = rec.Id,
                    PackName = rec.PackName,
                    Price = rec.Price,
                    PackSofts = context.PackSofts
                .Include(recPC => recPC.Soft)
                .Where(recPC => recPC.PackId == rec.Id)
                .ToDictionary(recPC => recPC.SoftId, recPC =>
                (recPC.Soft?.SoftName, recPC.Count))
                })
                .ToList();
            }
        }
    }
}