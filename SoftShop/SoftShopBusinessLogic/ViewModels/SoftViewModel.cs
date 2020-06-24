using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace SoftShopBusinessLogic.ViewModels
{

    public class SoftViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название ПО")]
        public string SoftName { get; set; }
    }
}