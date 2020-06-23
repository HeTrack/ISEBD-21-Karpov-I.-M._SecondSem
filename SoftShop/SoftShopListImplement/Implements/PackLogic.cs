using System;
using System.Collections.Generic;
using System.Text;
using SoftShopBusinessLogic.BindingModels;
using SoftShopBusinessLogic.Interfaces;
using SoftShopBusinessLogic.ViewModels;
using SoftShopListImplement.Models;

namespace SoftShopListImplement.Implements
{
    public class PackLogic : IPackLogic
    {
        private readonly DataListSingleton source;
        public PackLogic()
        {
            source = DataListSingleton.GetInstance();
        }
        public void CreateOrUpdate(PackBindingModel model)
        {
            Pack tempPack = model.Id.HasValue ? null : new Pack { Id = 1 };
            foreach (var pack in source.Packs)
            {
                if (pack.PackName == model.PackName && pack.Id != model.Id)
                {
                    throw new Exception("Уже есть изделие с таким названием");
                }
                if (!model.Id.HasValue && pack.Id >= tempPack.Id)
                {
                    tempPack.Id = pack.Id + 1;
                }
                else if (model.Id.HasValue && pack.Id == model.Id)
                {
                    tempPack = pack;
                }
            }
            if (model.Id.HasValue)
            {
                if (tempPack == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, tempPack);
            }
            else
            {
                source.Packs.Add(CreateModel(model, tempPack));
            }
        }
        public void Delete(PackBindingModel model)
        {
            for (int i = 0; i < source.PackSofts.Count; ++i)
            {
                if (source.PackSofts[i].PackId == model.Id)
                {
                    source.PackSofts.RemoveAt(i--);
                }
            }
            for (int i = 0; i < source.Packs.Count; ++i)
            {
                if (source.Packs[i].Id == model.Id)
                {
                    source.Packs.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
        private Pack CreateModel(PackBindingModel model, Pack pack)
        {
            pack.PackName = model.PackName;
            pack.Price = model.Price;
            int maxSFId = 0;
            for (int i = 0; i < source.PackSofts.Count; ++i)
            {
                if (source.PackSofts[i].Id > maxSFId)
                {
                    maxSFId = source.PackSofts[i].Id;
                }
                if (source.PackSofts[i].PackId == pack.Id)
                {
                    if
                    (model.PackSofts.ContainsKey(source.PackSofts[i].SoftId))
                    {
                        source.PackSofts[i].Count =
                        model.PackSofts[source.PackSofts[i].SoftId].Item2;
                        model.PackSofts.Remove(source.PackSofts[i].SoftId);
                    }
                    else
                    {
                        source.PackSofts.RemoveAt(i--);
                    }
                }
            }
            foreach (var sf in model.PackSofts)
            {
                source.PackSofts.Add(new PackSoft
                {
                    Id = ++maxSFId,
                    PackId = pack.Id,
                    SoftId = sf.Key,
                    Count = sf.Value.Item2
                });
            }
            return pack;
        }
        public List<PackViewModel> Read(PackBindingModel model)
        {
            List<PackViewModel> result = new List<PackViewModel>();
            foreach (var soft in source.Packs)
            {
                if (model != null)
                {
                    if (soft.Id == model.Id)
                    {
                        result.Add(CreateViewModel(soft));
                        break;
                    }
                    continue;
                }
                result.Add(CreateViewModel(soft));
            }
            return result;
        }
        private PackViewModel CreateViewModel(Pack Pack)
        {
            Dictionary<int, (string, int)> PackSofts = new Dictionary<int, (string, int)>();
            foreach (var sf in source.PackSofts)
            {
                if (sf.PackId == Pack.Id)
                {
                    string SoftName = string.Empty;
                    foreach (var Soft in source.Softs)
                    {
                        if (sf.SoftId == Soft.Id)
                        {
                            SoftName = Soft.SoftName;
                            break;
                        }
                    }
                    PackSofts.Add(sf.SoftId, (SoftName, sf.Count));
                }
            }
            return new PackViewModel
            {
                Id = Pack.Id,
                PackName = Pack.PackName,
                Price = Pack.Price,
                PackSofts = PackSofts
            };
        }
    }
}