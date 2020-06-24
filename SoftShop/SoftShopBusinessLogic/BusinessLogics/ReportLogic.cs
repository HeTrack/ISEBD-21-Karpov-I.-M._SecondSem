using SoftShopBusinessLogic.BindingModels;
using SoftShopBusinessLogic.Interfaces;
using SoftShopBusinessLogic.ViewModels;
using SoftShopBusinessLogic.HelperModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftShopBusinessLogic.BusinessLogics
{
    public class ReportLogic
    {
        private readonly ISoftLogic SoftLogic;
        private readonly IPackLogic PackLogic;
        private readonly IOrderLogic orderLogic;
        private readonly IWarehouseLogic warehouseLogic;
        public ReportLogic(IPackLogic PackLogic, ISoftLogic SoftLogic,
       IOrderLogic orderLogic, IWarehouseLogic warehouseLogic)
        {
            this.PackLogic = PackLogic;
            this.SoftLogic = SoftLogic;
            this.orderLogic = orderLogic;
            this.warehouseLogic = warehouseLogic;
        }
        /// <summary>
        /// Получение списка ПО с указанием, в каких пакетах используются
        /// </summary>
        /// <returns></returns>
        public List<ReportPackSoftViewModel> GetPackSoft()
        {
            var Packs = PackLogic.Read(null);
            var list = new List<ReportPackSoftViewModel>();
            foreach (var pack in Packs)
            {
                foreach (var sf in pack.PackSofts)
                {
                    var record = new ReportPackSoftViewModel
                    {
                        PackName = pack.PackName,
                        SoftName = sf.Value.Item1,
                        Count = sf.Value.Item2
                    };
                    list.Add(record);
                }
            }
            return list;
        }
        public List<ReportWarehouseSoftViewModel> GetWarehouseSofts()
        {
            var list = new List<ReportWarehouseSoftViewModel>();
            var warehouses = warehouseLogic.GetList();
            foreach (var warehouse in warehouses)
            {
                foreach (var sf in warehouse.WarehouseSofts)
                {
                    var record = new ReportWarehouseSoftViewModel
                    {
                        WarehouseName = warehouse.WarehouseName,
                        SoftName = sf.SoftName,
                        Count = sf.Count
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
            .OrderBy(recG => recG.Key)
            .ToList();

            return list;
        }
        /// <summary>
        /// Сохранение ПО в файл-Word
        /// </summary>
        /// <param name="model"></param>
        public void SavePacksToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список Пакетов",
                Packs = PackLogic.Read(null)
            });
        }
        /// <summary>
        /// Сохранение пакетов с указаеним ПО в файл-Excel
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
        /// Сохранение ПО в пакетах в файл-Pdf
        /// </summary>
        /// <param name="model"></param>
        public void SavePacksToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список ПО в пакетах",
                PackSofts = GetPackSoft(),
            });
        }
        public void SaveWarehousesToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список складов",
                Warehouses = warehouseLogic.GetList()
            });
        }
        public void SaveWarehouseSoftsToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список ПО в складах",
                Warehouses = warehouseLogic.GetList()
            });
        }
        public void SaveWarehouseSoftsToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список ПО",
                WarehouseSofts = GetWarehouseSofts()
            });
        }
    }
}
