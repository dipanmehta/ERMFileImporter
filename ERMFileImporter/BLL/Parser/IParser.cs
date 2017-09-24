using ERMFileImporter.BLL.Entity;

namespace ERMFileImporter.BLL.Parser
{
    public interface IParser
    {
        EnergyModel ParseLine(string line);
    }
}
