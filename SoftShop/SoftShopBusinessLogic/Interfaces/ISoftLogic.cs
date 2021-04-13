using System;
using System.Collections.Generic;
using System.Text;
using SoftShopBusinessLogic.ViewModels;
using SoftShopBusinessLogic.BindingModels;

namespace SoftShopBusinessLogic.Interfaces
{
    public interface ISoftLogic
    {
        List<SoftViewModel> Read(SoftBindingModel model);
        void CreateOrUpdate(SoftBindingModel model);
        void Delete(SoftBindingModel model);
    }
}