using System;
using System.Collections.Generic;
using System.Text;
using SoftShopBusinessLogic.BindingModels;
using SoftShopBusinessLogic.Interfaces;
using SoftShopBusinessLogic.ViewModels;
using System.Linq;
using SoftShopFileImplement;
using SoftShopFileImplement.Models;

namespace SoftShopFileImplement.Implements
{
    public class PackLogic : IPackLogic
    {
        private readonly FileDataListSingleton source;
        public PackLogic()
        {
            source = FileDataListSingleton.GetInstance();
        }
        public void CreateOrUpdate(PackBindingModel model)
        {
            Pack element = source.Packs.FirstOrDefault(rec => rec.PackName ==
            model.PackName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть пакет с таким названием");
            }
            if (model.Id.HasValue)
            {
                element = source.Packs.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
            }
            else
            {
                int maxId = source.Packs.Count > 0 ? source.Softs.Max(rec =>
                rec.Id) : 0;
                element = new Pack { Id = maxId + 1 };
                source.Packs.Add(element);
            }
            element.PackName = model.PackName;
            element.Price = model.Price;
            source.PackSofts.RemoveAll(rec => rec.PackId == model.Id &&
            !model.PackSofts.ContainsKey(rec.SoftId));
            var updateSofts = source.PackSofts.Where(rec => rec.PackId ==
            model.Id && model.PackSofts.ContainsKey(rec.SoftId));
            foreach (var updateSoft in updateSofts)
            {
                updateSoft.Count =
                model.PackSofts[updateSoft.SoftId].Item2;
                model.PackSofts.Remove(updateSoft.SoftId);
            }
            int maxPCId = source.PackSofts.Count > 0 ?
            source.PackSofts.Max(rec => rec.Id) : 0;
            foreach (var pc in model.PackSofts)
            {
                source.PackSofts.Add(new PackSoft
                {
                    Id = ++maxPCId,
                    PackId = element.Id,
                    SoftId = pc.Key,
                    Count = pc.Value.Item2
                });
            }
        }
        public void Delete(PackBindingModel model)
        {
            source.PackSofts.RemoveAll(rec => rec.PackId == model.Id);
            Pack element = source.Packs.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                source.Packs.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        public List<PackViewModel> Read(PackBindingModel model)
        {
            return source.Packs
            .Where(rec => model == null || rec.Id == model.Id)
            .Select(rec => new PackViewModel
            {
                Id = rec.Id,
                PackName = rec.PackName,
                Price = rec.Price,
                PackSofts = source.PackSofts
            .Where(recPC => recPC.PackId == rec.Id)
            .ToDictionary(recPC => recPC.SoftId, recPC =>
            (source.Softs.FirstOrDefault(recC => recC.Id ==
            recPC.SoftId)?.SoftName, recPC.Count))
            })
            .ToList();
        }
    }
}