using System;
using System.Collections.Generic;
using SoftShopListImplement.Models;

namespace SoftShopListImplement
{
    public class DataListSingleton
    {
        private static DataListSingleton instance;
        public List<Soft> Softs { get; set; }
        public List<Order> Orders { get; set; }
        public List<Pack> Packs { get; set; }
        public List<PackSoft> PackSofts { get; set; }
        public List<Client> Clients { get; set; }
        public List<Implementer> Implementers { get; set; }
        public List<MessageInfo> MessageInfoes { get; set; }
        private DataListSingleton()
        {
            Softs = new List<Soft>();
            Orders = new List<Order>();
            Packs = new List<Pack>();
            PackSofts = new List<PackSoft>();
            Clients = new List<Client>();
            Implementers = new List<Implementer>();
            MessageInfoes = new List<MessageInfo>();
        }
        public static DataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new DataListSingleton();
            }
            return instance;
        }
    }
}