using System;
using System.Collections.Generic;
using System.Text;
using SoftShopBusinessLogic.BindingModels;
using SoftShopBusinessLogic.Interfaces;
using SoftShopBusinessLogic.ViewModels;
using System.Linq;
using SoftShopFileListImplement;
using SoftShopFileListImplement.Models;

namespace SoftShopFileImplement.Implements
{
    public class SoftLogic : ISoftLogic
    {
        private readonly FileDataListSingleton source;
        public SoftLogic()
        {
            source = FileDataListSingleton.GetInstance();
        }
        public void CreateOrUpdate(SoftBindingModel model)
        {
            Soft element = source.Softs.FirstOrDefault(rec => rec.SoftName
           == model.SoftName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть ПО с таким названием");
            }
            if (model.Id.HasValue)
            {
                element = source.Softs.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
            }
            else
            {
                int maxId = source.Softs.Count > 0 ? source.Softs.Max(rec =>
               rec.Id) : 0;
                element = new Soft { Id = maxId + 1 };
                source.Softs.Add(element);
            }
            element.SoftName = model.SoftName;
        }
        public void Delete(SoftBindingModel model)
        {
            Soft element = source.Softs.FirstOrDefault(rec => rec.Id ==
           model.Id);
            if (element != null)
            {
                source.Softs.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        public List<SoftViewModel> Read(SoftBindingModel model)
        {
            return source.Softs
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