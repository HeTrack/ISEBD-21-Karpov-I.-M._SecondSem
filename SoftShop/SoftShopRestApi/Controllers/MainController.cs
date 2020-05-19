using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SoftShopBusinessLogic.BindingModels;
using SoftShopBusinessLogic.BusinessLogics;
using SoftShopBusinessLogic.Interfaces;
using SoftShopBusinessLogic.ViewModels;
using SoftShopRestApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SoftShopRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly IOrderLogic _order;
        private readonly IPackLogic _pack;
        private readonly MainLogic _main;
        public MainController(IOrderLogic order, IPackLogic pack, MainLogic main)
        {
            _order = order;
            _pack = pack;
            _main = main;
        }
        [HttpGet]
        public List<PackModel> GetPackList() => _pack.Read(null)?.Select(rec => Convert(rec)).ToList();
        [HttpGet]
        public PackModel GetPack(int packId) => Convert(_pack.Read(new PackBindingModel
        { Id = packId })?[0]);
        [HttpGet]
        public List<OrderViewModel> GetOrders(int clientId) => _order.Read(new OrderBindingModel
        { ClientId = clientId });
        [HttpPost]
        public void CreateOrder(CreateOrderBindingModel model) =>
       _main.CreateOrder(model);
        private PackModel Convert(PackViewModel model)
        {
            if (model == null) return null;
            return new PackModel
            {
                Id = model.Id,
                PackName = model.PackName,
                Price = model.Price
            };
        }
    }
}
