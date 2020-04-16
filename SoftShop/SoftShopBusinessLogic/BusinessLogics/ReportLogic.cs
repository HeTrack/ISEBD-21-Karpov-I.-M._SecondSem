using SoftShopBusinessLogic.BindingModels;
using SoftShopBusinessLogic.HelperModels;
using SoftShopBusinessLogic.Interfaces;
using SoftShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftShopBusinessLogic.BusinessLogics
{
    public class ReportLogic
    {
        private readonly ISoftLogic softLogic;
        private readonly IPackLogic packLogic;
        private readonly IOrderLogic orderLogic;
        public ReportLogic(IPackLogic packLogic, ISoftLogic softLogic,
            IOrderLogic orderLogic)
        {
            this.packLogic = packLogic;
            this.softLogic = softLogic;
            this.orderLogic = orderLogic;
        }
        public List<ReportPackSoftViewModel> GetPackSoft()
        {
            var softs = softLogic.Read(null);
            var packs = packLogic.Read(null);
            var list = new List<ReportPackSoftViewModel>();
            foreach (var soft in softs)
            {
                foreach (var pack in packs)
                {
                    if (pack.PackSofts.ContainsKey(soft.Id))
                    {
                        var record = new ReportPackSoftViewModel
                        {
                            PackName = pack.PackName,
                            SoftName = soft.SoftName,
                            Count = pack.PackSofts[soft.Id].Item2
                        };
                        list.Add(record);
                    }
                }
            }
            return list;
        }

        public List<ReportOrdersViewModel> GetOrders(ReportBindingModel model)
        {
            return orderLogic.Read(new OrderBindingModel
            {
                DateFrom = model.DateFrom,
                DateTo = model.DateTo
            })
            .Select(x => new ReportOrdersViewModel
            {
                DateCreate = x.DateCreate,
                PackName = x.PackName,
                Count = x.Count,
                Sum = x.Sum,
                Status = x.Status
            })
            .ToList();
        }

        public void SavePacksToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список пакетов",
                Packs = packLogic.Read(null)
            });
        }

        public void SaveOrdersToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                DateFrom = model.DateFrom.Value,
                DateTo = model.DateTo.Value,
                FileName = model.FileName,
                Title = "Список заказов",
                Orders = GetOrders(model)
            });
        }

     
        public void SavePackSoftsToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PDFInfo
            {
                FileName = model.FileName,
                Title = "Детализация пакетов ",
                PackSofts = GetPackSoft()
            });
        }
    }
}