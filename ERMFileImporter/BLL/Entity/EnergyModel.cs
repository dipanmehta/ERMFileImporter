using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERMFileImporter.BLL.Entity
{
    public class EnergyModel
    {
        public string MeterPoint { get; set; }
        public string SerialNumber { get; set; }
        public string PlantCode { get; set; }
        public DateTime MeterDateTime { get; set; }
        public double MedianField { get; set; }
    }
}
