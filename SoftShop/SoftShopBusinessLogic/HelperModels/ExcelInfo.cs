using SoftShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftShopBusinessLogic.HelperModels
{
    class ExcelInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public List<ReportPackSoftViewModel> PackSofts { get; set; }
        public List<ReportOrdersViewModel> Orders { get; set; }
    }
}
