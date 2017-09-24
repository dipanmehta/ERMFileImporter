using System;
using System.IO;
using System.Linq;
using ERMFileImporter.BLL;
using ERMFileImporter.BLL.Parser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static System.Configuration.ConfigurationManager;
using Microsoft.Practices.Unity;
namespace ERMFileImporter.Test
{
    [TestClass]
    public class FileProcessorTest
    {
        
        private IUnityContainer container;
        private string filePath;

        [TestInitialize]
        public void FileProcessortTestInitialize()
        {
            this.filePath = AppSettings.Get("MeterFilePath");
            container = UnityConfig.GetConfiguredContainer();
        }

        [TestMethod]
        public void TestGetMedianForVpFile()
        {
            try
            {
                var fileName = Path.Combine(filePath, "LP_210095893_20150901T011608049.csv");
                var fileProcessor = container.Resolve<IFileProcessor>
                (new ParameterOverride("parser", container.Resolve<IParser>("LP")),
                    new ParameterOverride("filePath", fileName));

                fileProcessor.Import();
                var currentMedian = fileProcessor.GetMedian();
                Assert.IsNotNull(currentMedian);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [TestMethod]
        public void TestGetDataOverMedian()
        {
            var fileName = Path.Combine(filePath, "LP_210095893_20150901T011608049.csv");
            var fileProcessor = container.Resolve<IFileProcessor>
            (new ParameterOverride("parser", container.Resolve<IParser>("LP")),
                new ParameterOverride("filePath", fileName));

            fileProcessor.Import();
            var listOverMedian = fileProcessor.GetDataOverMedian();
            Assert.IsTrue(listOverMedian.Any());

        }

        [TestMethod]
        public void TestGetDataBelowMedian()
        {
            var fileName = Path.Combine(filePath, "LP_210095893_20150901T011608049.csv");
            var fileProcessor = container.Resolve<IFileProcessor>
            (new ParameterOverride("parser", container.Resolve<IParser>("LP")),
                new ParameterOverride("filePath", fileName));

            fileProcessor.Import();
            var listOverMedian = fileProcessor.GetDataBelowMedian();
            Assert.IsTrue(listOverMedian.Any());

        }
    }
}
