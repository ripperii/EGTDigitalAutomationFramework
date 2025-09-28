using EGTDigitalAutomationFramework.Pages;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGTDigitalAutomationFramework.Core
{
    public class PageFactory(IPage page)
    {
        public AutomationPracticeFormPage FormPage => new(page);
        public SubmitedDataTablePage SubmitedDataTablePage => new(page);
    }
}
