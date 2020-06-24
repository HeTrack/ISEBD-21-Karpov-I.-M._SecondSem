using SoftShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftShopBusinessLogic.BusinessLogics
{
   public class PDFInfo
    {
       
            public string FileName { get; set; }
            public string Title { get; set; }
            public List<ReportPackSoftViewModel> PackSofts { get; set; }
    }
}
