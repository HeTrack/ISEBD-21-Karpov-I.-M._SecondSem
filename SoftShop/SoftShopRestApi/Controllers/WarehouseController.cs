using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using SoftShopBusinessLogic.BindingModels;
using SoftShopBusinessLogic.Interfaces;
using SoftShopBusinessLogic.ViewModels;
using SoftShopRestApi.Models;

namespace SoftShopRestApi.Controllers
{
        [Route("api/[controller]/[action]")]
        [ApiController]
        public class WarehouseController : ControllerBase
        {
            private readonly IWarehouseLogic _warehouse;
            private readonly ISoftLogic _soft;
            public WarehouseController(IWarehouseLogic warehouse, ISoftLogic soft)
            {
                _warehouse = warehouse;
                _soft = soft;
            }
            [HttpGet]
            public List<WarehouseModel> GetWarehousesList() => _warehouse.GetList()?.Select(rec => Convert(rec)).ToList();
            [HttpGet]
            public List<SoftViewModel> GetSoftsList() => _soft.Read(null)?.ToList();
            [HttpGet]
            public WarehouseModel GetWarehouse(int WarehouseId) => Convert(_warehouse.GetElement(WarehouseId));
            [HttpPost]
            public void CreateOrUpdateWarehouse(WarehouseBindingModel model)
            {
                if (model.Id.HasValue)
                {
                    _warehouse.UpdElement(model);
                }
                else
                {
                    _warehouse.AddElement(model);
                }
            }
            [HttpPost]
            public void DeleteWarehouse(WarehouseBindingModel model) => _warehouse.DelElement(model);
            [HttpPost]
            public void FillWarehouse(WarehouseSoftBindingModel model) => _warehouse.FillWarehouse(model);
            private WarehouseModel Convert(WarehouseViewModel model)
            {
                if (model == null) return null;

                return new WarehouseModel
                {
                    Id = model.Id,
                    WarehouseName = model.WarehouseName,
                    WarehouseSofts = model.WarehouseSofts
                };
            }
        }
    }