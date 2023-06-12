using Tools;

namespace ConsoleAppDependencyInjection {
    internal class Program {
        static void Main(string[] args) { 
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