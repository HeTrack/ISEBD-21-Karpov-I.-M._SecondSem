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
                Order element = context.Orders.FirstOrDefault(rec => rec.Id ==
               model.Id);
                if (element != null)
                {
                    context.Orders.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        public List<OrderViewModel> Read(OrderBindingModel model)
        {
            using (var context = new SoftShopDatabase())
            {
                return context.Orders
                .Include(rec => rec.Pack)
            .Where(rec => model == null || rec.Id == model.Id)
            .Select(rec => new OrderViewModel
            {
                Id = rec.Id,
                PackName = rec.Pack.PackName,
                Count = rec.Count,
                Sum = rec.Sum,
                Status = rec.Status,
                DateCreate = rec.DateCreate,
                DateImplement = rec.DateImplement
            })
            .ToList();
            }
        }
    }
}