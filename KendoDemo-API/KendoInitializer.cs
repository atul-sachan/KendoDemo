using KendoDemo.API.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KendoDemo.API
{
    internal static class KendoInitializer
    {
        private static bool _initialized = false;
        private static object _lock = new object();
        private static List<Kendo> kendos;
        private static List<KendoMap> kendosMap;

        public static void Seed(KendoContext context)
        {
            AddKendos(context);
        }

        internal static void Initialize(KendoContext context)
        {
            if (!_initialized)
            {
                lock (_lock)
                {
                    if (_initialized)
                        return;

                    InitializeData(context);
                }
            }
        }

        private static void AddKendos(KendoContext context)
        {
            var data = System.IO.File.ReadAllText("data.json");
            kendosMap = JsonConvert.DeserializeObject<List<KendoMap>>(data);
            int i = 0;
            foreach (var kendo in kendosMap)
            {
                Kendo k = new Kendo();
                k.Id = ++i;
                k.IsActive = kendo.IsActive;
                k.Phone = kendo.Phone;
                k.Picture = kendo.Picture;
                k.Registered = kendo.Registered;
                k.FullName = kendo.FullName;
                k.FavoriteFurit = kendo.FavoriteFurit;
                k.EyeColor = kendo.EyeColor;
                k.Email = kendo.Email;
                k.Company = kendo.Company;
                k.Balance = kendo.Balance;
                k.Age = kendo.Age;
                k.Address = kendo.Address;
                k.About = kendo.About;
                context.Kendos.Add(k);
            }
            if (!context.Kendos.Any())
            {
                context.SaveChanges();
            }
        }

        private static void InitializeData(KendoContext context)
        {
            context.Database.Migrate();
            Seed(context);
        }
    }
}
