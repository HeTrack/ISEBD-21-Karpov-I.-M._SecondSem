using SoftShopBusinessLogic.BindingModels;
using SoftShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftShopBusinessLogic.Interfaces
{
    public interface IMessageInfoLogic
    {
        List<MessageInfoViewModel> Read(MessageInfoBindingModel model);
        void Create(MessageInfoBindingModel model);
    }
}