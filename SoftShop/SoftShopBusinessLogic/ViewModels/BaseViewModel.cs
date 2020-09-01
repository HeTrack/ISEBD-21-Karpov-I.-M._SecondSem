using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using SoftShopBusinessLogic.Attributes;

namespace SoftShopBusinessLogic.ViewModels
{
    /// <summary>
    /// Базовый класс для View-моделей
    /// </summary>
    [DataContract]
    public abstract class BaseViewModel
    {
        [Column(visible: false)]
        [DataMember]
        public int Id { get; set; }
        public abstract List<string> Properties();
    }
}