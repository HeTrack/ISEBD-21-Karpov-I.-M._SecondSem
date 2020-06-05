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
    public class SoftLogic : ISoftLogic
    {
        public void CreateOrUpdate(SoftBindingModel model)
        {
            using (var context = new SoftShopDatabase())
            {
                Soft element = context.Softs.FirstOrDefault(rec =>
                rec.SoftName == model.SoftName && rec.Id != model.Id);
                if (element != null)
                {
                    throw new Exception("Уже есть по с таким названием");
                }
                if (model.Id.HasValue)
                {
                    element = context.Softs.FirstOrDefault(rec => rec.Id ==
                    model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
                else
                {
                    element = new Soft();
                    context.Softs.Add(element);
                }
                element.SoftName = model.SoftName;
                context.SaveChanges();
            }
        }
        public void Delete(SoftBindingModel model)
        {
            using (var context = new SoftShopDatabase())
            {
                Soft element = context.Softs.FirstOrDefault(rec => rec.Id ==
                model.Id);
                if (element != null)
                {
                    context.Softs.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        public List<SoftViewModel> Read(SoftBindingModel model)
        {
            using (var context = new SoftShopDatabase())
            {
                return context.Softs
                .Where(rec => model == null || rec.Id == model.Id)
                .Select(rec => new SoftViewModel
                {
                    Id = rec.Id,
                    SoftName = rec.SoftName
                })
                .ToList();
            }
        }
    }
}