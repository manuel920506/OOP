using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppDependencyInjection {
    public static class IntegrationParameters {
        public static double GetExtra() {
            return double.Parse(ConfigurationManager.AppSettings["Extra"] ?? "0");
        }

        public static double GetSales() {
            return double.Parse(ConfigurationManager.AppSettings["Sales"] ?? "0");
        }

        public static string GetPathLog() {
            return ConfigurationManager.AppSettings["PathLog"] ?? String.Empty;
        }
    }
}
