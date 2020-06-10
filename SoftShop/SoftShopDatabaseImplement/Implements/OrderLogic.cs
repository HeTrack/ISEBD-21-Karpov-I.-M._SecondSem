using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SoftShopBusinessLogic.BindingModels;
using SoftShopBusinessLogic.Interfaces;
using SoftShopBusinessLogic.ViewModels;
using SoftShopDatabaseImplement.Models;
using System.Linq;

namespace SoftShopDatabaseImplement.Implements
{
    public class OrderLogic : IOrderLogic
    {
        public void CreateOrUpdate(OrderBindingModel model)
        {
            using (var context = new SoftShopDatabase())
            {
                Order element;
                if (model.Id.HasValue)
                {
                    element = context.Orders.FirstOrDefault(rec => rec.Id ==
                   model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
                else
                {
                    element = new Order();
                    context.Orders.Add(element);
                }
                element.PackId = model.PackId == 0 ? element.PackId : model.PackId;
                element.Count = model.Count;
                element.Sum = model.Sum;
                element.Status = model.Status;
                element.DateCreate = model.DateCreate;
                element.DateImplement = model.DateImplement;
                context.SaveChanges();
            }
        }

        public void Delete(OrderBindingModel model)
        {
            using (var context = new SoftShopDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Order order = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                        if (order != null)
                        {
                            context.Orders.Remove(order);
                        }
                        else
                        {
                            throw new Exception("Элемент не найден");
                        }
                        context.SaveChanges();
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

        public List<OrderViewModel> Read(OrderBindingModel model)
        {
            using (var context = new SoftShopDatabase())
            {
                return context.Orders.Where(rec => model == null ||
                     (rec.Id == model.Id && model.Id.HasValue) ||
                     (model.DateFrom.HasValue && model.DateTo.HasValue &&
                     (rec.DateCreate >= model.DateFrom) && (rec.DateCreate <= model.DateTo))).ToList().Select(rec => new OrderViewModel()
                 {
                         Id = rec.Id,
                         PackId = rec.PackId,
                         PackName = context.Packs.FirstOrDefault((r) => r.Id == rec.PackId).PackName,
                         Count = rec.Count,
                         DateCreate = rec.DateCreate,
                         DateImplement = rec.DateImplement,
                         Status = rec.Status,
                         Sum = rec.Sum
                     })
            .ToList();
            }
        }
    }
}