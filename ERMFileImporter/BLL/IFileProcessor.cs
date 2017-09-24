using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERMFileImporter.BLL.Entity;

namespace ERMFileImporter.BLL
{
    public interface IFileProcessor
    {
        void Import();
        double GetMedian();
        IEnumerable<EnergyModel> GetDataOverMedian();
        IEnumerable<EnergyModel> GetDataBelowMedian();
    }
}
