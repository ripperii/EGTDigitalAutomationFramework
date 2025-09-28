using EGTDigitalAutomationFramework.Configs;
using EGTDigitalAutomationFramework.Models;
using EGTDigitalAutomationFramework.Pages;
using EGTDigitalAutomationFramework.Tests.UI.Base;
using EGTDigitalAutomationFramework.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EGTDigitalAutomationFramework.Tests.UI
{
    [Collection("Playwright collection")]
    public class PracticeFormTest(PlaywrightFixture fixture) : UIBaseTest
    {
        private readonly PlaywrightFixture _fixture = fixture;

        public static TheoryData<TestFormData> FormTestData = FormTestDataGenerator.Generate(2);

        [Theory]
        [MemberData(nameof(FormTestData))]
        public async Task FillAndSubmitFormTest(TestFormData data)
        {
            Log.Info("Navigating to Automation Practice Form");

            await _fixture.Page.GotoAsync(FrameworkConfigProvider.Config.BaseUrl);

            AutomationPracticeFormPage formPage = _fixture.PageFactory.FormPage;

            await formPage.FillFirstNameAsync(data.FirstName);
            await formPage.FillLastNameAsync(data.LastName);
            await formPage.FillEmailAsync(data.Email);
            await formPage.SelectGenderAsync(data.Gender);
            await formPage.FillMobileAsync(data.Mobile);
            await formPage.SetDateOfBirthAsync(data.BirthDate);
            await formPage.AddSubjectsAsync(data.Subjects);
            await formPage.SelectHobbiesAsync(data.Hobbies);
            await formPage.FillCurrentAddressAsync(data.CurrentAddress);
            await formPage.SelectStateAsync(data.State);
            await formPage.SelectCityAsync(data.City);
            await formPage.SubmitAsync();

            Log.Info("Entered credentials.");

            PracticeFormAssertions.AssertSubmitedData(data, _fixture.PageFactory.SubmitedDataTablePage);

            await _fixture.PageFactory.SubmitedDataTablePage.ClickClose();

        }
    }
}
