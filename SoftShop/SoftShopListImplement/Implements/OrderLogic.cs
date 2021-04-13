using System;
using System.Collections.Generic;
using System.Text;
using SoftShopBusinessLogic.BindingModels;
using SoftShopBusinessLogic.Enums;
using SoftShopBusinessLogic.Interfaces;
using SoftShopBusinessLogic.ViewModels;
using SoftShopListImplement;
using SoftShopListImplement.Models;

namespace SoftShopListImplement.Implements
{
    public class OrderLogic : IOrderLogic
    {

        private readonly DataListSingleton source;
        public OrderLogic()
        {
            source = DataListSingleton.GetInstance();
        }
        public void CreateOrUpdate(OrderBindingModel model)
        {
            Order tempOrder = model.Id.HasValue ? null : new Order
            {
                Id = 1
            };
            foreach (var Order in source.Orders)
            {
                if (!model.Id.HasValue && Order.Id >= tempOrder.Id)
                {
                    tempOrder.Id = Order.Id + 1;
                }
                else if (model.Id.HasValue && Order.Id == model.Id)
                {
                    tempOrder = Order;
                }
            }
            if (model.Id.HasValue)
            {
                if (tempOrder == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, tempOrder);
            }
            else
            {
                source.Orders.Add(CreateModel(model, tempOrder));
            }
        }
        public void Delete(OrderBindingModel model)
        {
            for (int i = 0; i < source.Orders.Count; ++i)
            {
                if (source.Orders[i].Id == model.Id.Value)
                {
                    source.Orders.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }

        public List<OrderViewModel> Read(OrderBindingModel model)
        {
            List<OrderViewModel> result = new List<OrderViewModel>();
            foreach (var Order in source.Orders)
            {
                if (model != null)
                {
                    if (Order.Id == model.Id || (model.DateFrom.HasValue && model.DateTo.HasValue && Order.DateCreate >= model.DateFrom && Order.DateCreate <= model.DateTo)
                        || model.ClientId.HasValue && Order.ClientId == model.ClientId
                        || model.FreeOrders.HasValue && model.FreeOrders.Value
                    || model.ImplementerId.HasValue && Order.ImplementerId == model.ImplementerId && Order.Status == OrderStatus.Выполняется)
                    {
                        result.Add(CreateViewModel(Order));
                        break;
                    }
                    continue;
                }
                result.Add(CreateViewModel(Order));
            }
            return result;
        }

        private Order CreateModel(OrderBindingModel model, Order Order)
        {
            Order.PackId = model.PackId == 0 ? Order.PackId : model.PackId;
            Order.ClientId = (int)model.ClientId;
            Order.Count = model.Count;
            Order.ImplementerId = model.ImplementerId;
            Order.Sum = model.Sum;
            Order.Status = model.Status;
            Order.DateCreate = model.DateCreate;
            Order.DateImplement = model.DateImplement;
            return Order;
        }

        private OrderViewModel CreateViewModel(Order Order)
        {
            string PackName = "";
            for (int j = 0; j < source.Packs.Count; ++j)
            {
                if (source.Packs[j].Id == Order.PackId)
                {
                    PackName = source.Packs[j].PackName;
                    break;
                }
            }
            return new OrderViewModel
            {
                Id = Order.Id,
                PackName = PackName,
                ClientId = Order.ClientId,
                Count = Order.Count,
                Sum = Order.Sum,
                Status = Order.Status,
                DateCreate = Order.DateCreate,
                DateImplement = Order.DateImplement
            };
        }
    }
}