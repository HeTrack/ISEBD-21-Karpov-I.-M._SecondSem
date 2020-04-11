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
            foreach (var Pack in source.Packs)
            {
                if (Pack.PackName == model.PackName && Pack.Id != model.Id)
                {
                    throw new Exception("Уже есть пакет с таким названием");
                }
                if (!model.Id.HasValue && Pack.Id >= tempPack.Id)
                {
                    tempPack.Id = Pack.Id + 1;
                }
                else if (model.Id.HasValue && Pack.Id == model.Id)
                {
                    tempPack = Pack;
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
            // удаляем записи по ПО при удалении пакеты
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
        private Pack CreateModel(PackBindingModel model, Pack Pack)
        {
            Pack.PackName = model.PackName;
            Pack.Price = model.Price;
            //обновляем существуюущее ПО и ищем максимальный идентификатор
            int maxPCId = 0;
            for (int i = 0; i < source.PackSofts.Count; ++i)
            {
                if (source.PackSofts[i].Id > maxPCId)
                {
                    maxPCId = source.PackSofts[i].Id;
                }
                if (source.PackSofts[i].PackId == Pack.Id)
                {
                    // если в модели пришла запись ПО с таким id
                    if
                    (model.PackSofts.ContainsKey(source.PackSofts[i].SoftId))
                    {
                        // обновляем количество
                        source.PackSofts[i].Count =
                        model.PackSofts[source.PackSofts[i].SoftId].Item2;
                        model.PackSofts.Remove(source.PackSofts[i].PackId);
                        // из модели убираем эту запись, чтобы остались только не просмотренные
                    }
                    else
                    {
                        source.PackSofts.RemoveAt(i--);
                    }
                }
            }
            // новые записи
            foreach (var pc in model.PackSofts)
            {
                source.PackSofts.Add(new PackSoft
                {
                    Id = ++maxPCId,
                    PackId = Pack.Id,
                    SoftId = pc.Key,
                    Count = pc.Value.Item2
                });
            }
            return Pack;
        }
        public List<PackViewModel> Read(PackBindingModel model)
        {
            List<PackViewModel> result = new List<PackViewModel>();
            foreach (var Soft in source.Packs)
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
        private PackViewModel CreateViewModel(Pack Pack)
        {
            Dictionary<int, (string, int)> PackSofts = new Dictionary<int,
    (string, int)>();
            foreach (var pc in source.PackSofts)
            {
                if (pc.PackId == Pack.Id)
                {
                    string SoftName = string.Empty;
                    foreach (var Soft in source.Softs)
                    {
                        if (pc.SoftId == Soft.Id)
                        {
                            SoftName = Soft.SoftName;
                            break;
                        }
                    }
                    PackSofts.Add(pc.SoftId, (SoftName, pc.Count));
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