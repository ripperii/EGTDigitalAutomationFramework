using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGTDigitalAutomationFramework.Tests.UI.Base
{
    public abstract class UIBaseTest : IDisposable
    {
        protected UIBaseTest()
        {
            Console.WriteLine("Setup");
        }
        public void Dispose()
        {
            Console.WriteLine("Tear Down");
        }
    }
}
