using LiveDemo_MVC.Data;
using LiveDemo_MVC.Data.Migrations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;

namespace LiveDemo_MVC.IntegrationTests
{
    [TestClass]
    public class TestsInitializer
    {
        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<LiveDemoEfDbContext, Configuration>());
        }
    }
}