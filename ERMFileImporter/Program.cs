using System;
using System.Collections.Generic;
using System.IO;
using ERMFileImporter.BLL;
using ERMFileImporter.BLL.Entity;
using ERMFileImporter.BLL.Parser;
using static System.Configuration.ConfigurationManager;
using Microsoft.Practices.Unity;

namespace ERMFileImporter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //File Path is Configurable in app.config file.
            var dir = AppSettings.Get("MeterFilePath");
            //Unity IOC to register type
            var container = UnityConfig.GetConfiguredContainer();

            var files = Directory.GetFiles(dir);
            foreach (var file in files)
            {

                try
                {
                    //Get file name and then get file type. Here File Type is LP and TOU
                    //I have used following approach to differentiate two different files.
                    var fileName = Path.GetFileName(file);
                    var fileType = fileName.Split('_')[0];

                    //based on File Type, Parser is created to parse csv file
                    //i.e I have created two parser class 1) for LP and 2) for TOU
                    //if in future new file type  or template is introduced, we only need to create parser for that type and hookit into FileProcessor constructor
                    //Also, File Name is provided from main program to differentiate source and implementation

                    var fileProcessor = container.Resolve<IFileProcessor>
                     (new ParameterOverride("parser", container.Resolve<IParser>(fileType.ToUpper())),
                         new ParameterOverride("filePath", file));

                    fileProcessor.Import();
                    var currentMedian = fileProcessor.GetMedian();
                    var listOVerMedian = fileProcessor.GetDataOverMedian();
                    Console.WriteLine("Display 20% of above Median for file name  " + fileName);
                    PrintData(fileName, currentMedian, listOVerMedian);
                    var listBelowMedian = fileProcessor.GetDataBelowMedian();
                    Console.WriteLine("========================================================");
                    Console.WriteLine("Display 20% of below Median for file name  " + fileName);
                    PrintData(fileName, currentMedian, listBelowMedian);
                    Console.WriteLine("========================================================");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }


            }
            Console.ReadLine();

        }

        public static void PrintData(string fileName, double currentMedian, IEnumerable<EnergyModel> dataList)
        {
            Console.WriteLine(string.Format("{0,-25} {1,30} {2,10} {3,-60}", "File Name", "DateTime", "Value", "Median Value"));
            foreach (var model in dataList)
            {
                Console.WriteLine(string.Format("{0,25} {1,25} {2,5} {3,5}", fileName, model.MeterDateTime.ToString(), model.MedianField, currentMedian));
            }
        }
    }
}
