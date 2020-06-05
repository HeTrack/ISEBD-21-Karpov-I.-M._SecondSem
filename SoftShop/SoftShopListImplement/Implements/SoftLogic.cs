using System;
using System.Collections.Generic;
using System.Text;
using SoftShopBusinessLogic.BindingModels;
using SoftShopBusinessLogic.Interfaces;
using SoftShopBusinessLogic.ViewModels;
using SoftShopListImplement.Models;

namespace SoftShopListImplement.Implements
{
    public class SoftLogic : ISoftLogic
    {
        private readonly DataListSingleton source;
        public SoftLogic()
        {
            source = DataListSingleton.GetInstance();
        }
        public void CreateOrUpdate(SoftBindingModel model)
        {
            Soft tempSoft = model.Id.HasValue ? null : new Soft
            {
                Id = 1
            };
            foreach (var Soft in source.Softs)
            {
                if (Soft.SoftName == model.SoftName && Soft.Id !=
                model.Id)
                {
                    throw new Exception("Уже есть по с таким названием");
                }
                if (!model.Id.HasValue && Soft.Id >= tempSoft.Id)
                {
                    tempSoft.Id = Soft.Id + 1;
                }
                else if (model.Id.HasValue && Soft.Id == model.Id)
                {
                    tempSoft = Soft;
                }
            }
            if (model.Id.HasValue)
            {
                if (tempSoft == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, tempSoft);
            }
            else
            {
                source.Softs.Add(CreateModel(model, tempSoft));
            }
        }
        public void Delete(SoftBindingModel model)
        {
            for (int i = 0; i < source.Softs.Count; ++i)
            {
                if (source.Softs[i].Id == model.Id.Value)
                {
                    source.Softs.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
        public List<SoftViewModel> Read(SoftBindingModel model)
        {
            List<SoftViewModel> result = new List<SoftViewModel>();
            foreach (var Soft in source.Softs)
            {
                if (model != null)
                {
                    if (Soft.Id == model.Id)
                    {
                        result.Add(CreateViewModel(Soft));
                        break;
                    }
                    continue;
                }
                result.Add(CreateViewModel(Soft));
            }
            return result;
        }
        private Soft CreateModel(SoftBindingModel model, Soft Soft)
        {
            Soft.SoftName = model.SoftName;
            return Soft;
        }
        private SoftViewModel CreateViewModel(Soft Soft)
        {
            return new SoftViewModel
            {
                Id = Soft.Id,
                SoftName = Soft.SoftName
            };
        }
    }
}