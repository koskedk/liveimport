using System;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace LiveImport.Core.Tests
{
    [SetUpFixture]
    public class TestInitializer
    {
        public static IServiceProvider ServiceProvider;
    
        [OneTimeSetUp]
        public void Init()
        {
            var services = new ServiceCollection();
            services.AddCore();
            ServiceProvider = services.BuildServiceProvider();
        }
    }
}