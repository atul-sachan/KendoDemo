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
            kendos = JsonConvert.DeserializeObject<List<Kendo>>(data);
            foreach (var kendo in kendos)
            {
                context.Kendos.Add(kendo);
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
