using Tools;
using Microsoft.Extensions.DependencyInjection; 
using System.Configuration;

namespace ConsoleAppDependencyInjection {
    internal class Program {
        static void Main(string[] args) {
            ////setup our DI, need a concrete type
            var serviceProvider = new ServiceCollection()
                .AddSingleton<Tools.Factory.ILogger>((factory) => {
                    return (Tools.Factory.ILogger)(new Tools.Factory.FileLoggerFactory(ConfigurationManager.AppSettings["PathLog"])).GetLogger();
                })
                .BuildServiceProvider();

            var loggerMadeFactory = serviceProvider.GetService<Tools.Factory.ILogger>();
            var loggerMadeFactoryBis = serviceProvider.GetService<Tools.Factory.ILogger>();

            loggerMadeFactory.LogInfo("Logger fatto in fabbrica");

            Console.WriteLine(loggerMadeFactory == loggerMadeFactoryBis);

            var extra = IntegrationParameters.GetExtra();
            
            ILogger logger = ConsoleLogger.GetInstance();
            ILogger logger2 = FileLogger.GetInstance();

            var dbMigrator = new DbMigrator(logger);
            dbMigrator.Migrate();

            ILogger loggerbis = ConsoleLogger.GetInstance();
            Console.WriteLine(logger == loggerbis);

            var dbMigrator2 = new DbMigrator(logger2);
            dbMigrator2.Migrate();
        }
    }
}