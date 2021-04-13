using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.Serialization;
using SoftShopBusinessLogic.Attributes;

namespace SoftShopBusinessLogic.ViewModels
{
    [DataContract]
    public class PackViewModel : BaseViewModel
    {
        [Column(title: "Название пакета", gridViewAutoSize: GridViewAutoSize.Fill)]
        [DataMember]    
        public string PackName { get; set; }
        [Column(title: "Цена", width: 50)]
        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
        public Dictionary<int, (string, int)> PackSofts { get; set; }
        public override List<string> Properties() => new List<string>
        {
            "Id",
            "PackName",
            "Price"
        };
    }
}