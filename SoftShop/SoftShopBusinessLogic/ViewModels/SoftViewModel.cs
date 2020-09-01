using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using SoftShopBusinessLogic.Attributes;

namespace SoftShopBusinessLogic.ViewModels
{

    public class SoftViewModel : BaseViewModel
    {
        [Column(title: "ПО", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string SoftName { get; set; }
        public override List<string> Properties() => new List<string>
        {
            "Id",
            "SoftName"
        };
    }
}