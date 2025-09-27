using EGTDigitalAutomationFramework.Configs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGTDigitalAutomationFramework.Tests.API.Base
{
    public abstract class APITestBase : IDisposable
    {
        protected APITestBase() 
        {
            Console.WriteLine("Setup");
        }
        public void Dispose()
        {
            Console.WriteLine("Tear Down");
        }
    }
}
