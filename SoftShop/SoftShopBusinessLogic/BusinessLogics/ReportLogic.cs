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
            this.softLogic = softLogic;
            this.packLogic = packLogic;
            this.orderLogic = orderLogic;
        }
        public List<ReportPackSoftViewModel> GetPackSoft()
        {
            var packs = packLogic.Read(null);
            var list = new List<ReportPackSoftViewModel>();
            foreach (var pack in packs)
            {
                foreach (var ps in pack.PackSofts)
                {
                    var record = new ReportPackSoftViewModel
                    {
                        PackName = pack.PackName,
                        SoftName = ps.Value.Item1,
                        Count = ps.Value.Item2
                    };
                    list.Add(record);
                }
            }

            return list;
        }

        public List<IGrouping<DateTime, OrderViewModel>> GetOrders(ReportBindingModel model)
        {         
            var list = orderLogic
            .Read(new OrderBindingModel
            {
                DateFrom = model.DateFrom,
                DateTo = model.DateTo
            })          
            .GroupBy(rec => rec.DateCreate.Date)
            .OrderBy(recc => recc.Key)
            .ToList();

            return list;
        }

        /// <summary>
        /// Сохранение компонент в файл-Word
        /// </summary>
        /// <param name="model"></param>
        public void SavePacksToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список пакетов",
                Packs = packLogic.Read(null)
            });
        }

        /// <summary>
        /// Сохранение закусок с указаеним продуктов в файл-Excel
        /// </summary>
        /// <param name="model"></param>
        public void SaveOrdersToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {              
                FileName = model.FileName,
                Title = "Список заказов",
                Orders = GetOrders(model)
            });
        }

        /// <summary>
        /// Сохранение закусок с продуктами в файл-Pdf
        /// </summary>
        /// <param name="model"></param>
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