using System;
using System.Collections.Generic;
using System.Text;
using SoftShopBusinessLogic.ViewModels;
using SoftShopBusinessLogic.BindingModels;

namespace SoftShopBusinessLogic.Interfaces
{
    public interface IPackLogic
    {
        List<PackViewModel> Read(PackBindingModel model);
        void CreateOrUpdate(PackBindingModel model);
        void Delete(PackBindingModel model);
    }
}