using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERMFileImporter.BLL.Entity;

namespace ERMFileImporter.BLL.Parser
{
    public class TOUParser : IParser
    {
        public EnergyModel ParseLine(string line)
        {
            var data = line.Split(',');
            return new EnergyModel()
            {
                MeterPoint = data[0],
                SerialNumber = data[1],
                PlantCode = data[2],
                MeterDateTime = DateTime.Parse(data[3]),
                MedianField = double.Parse(data[5])
            };
        }
    }
}
