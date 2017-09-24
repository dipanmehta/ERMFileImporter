using System;
using ERMFileImporter.BLL;
using ERMFileImporter.BLL.Parser;
using Microsoft.Practices.Unity;

namespace ERMFileImporter
{
    public class UnityConfig
    {
        private static readonly Lazy<IUnityContainer> _container = new Lazy<IUnityContainer>(() => {

            IUnityContainer container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        public static IUnityContainer GetConfiguredContainer()
        {
            return _container.Value;
        }

        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IFileProcessor, MeterFileProcessor>();
            container.RegisterType<IParser, LPParser>("LP");
            container.RegisterType<IParser, TOUParser>("TOU");
        }
    }
}
