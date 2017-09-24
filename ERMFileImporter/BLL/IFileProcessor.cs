using System.Collections.Generic;
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
