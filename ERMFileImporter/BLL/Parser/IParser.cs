using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERMFileImporter.BLL.Entity;

namespace ERMFileImporter.BLL.Parser
{
    public interface IParser
    {
        EnergyModel ParseLine(string line);
    }
}
