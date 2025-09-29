using Allure.Net.Commons;
using Allure.Xunit.Attributes;
using EGTDigitalAutomationFramework.Configs;
using EGTDigitalAutomationFramework.Models;
using EGTDigitalAutomationFramework.Pages;
using EGTDigitalAutomationFramework.Tests.UI.Base;
using EGTDigitalAutomationFramework.Utilities;
using static Microsoft.Playwright.Assertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Allure.Xunit.Attributes.Steps;

namespace EGTDigitalAutomationFramework.Tests.UI
{
    [Collection("Playwright collection")]
    public class PracticeFormTests(PlaywrightFixture fixture) : UIBaseTest
    {
        private readonly PlaywrightFixture _fixture = fixture;

        public static TheoryData<TestFormData> FormTestData = FormTestDataGenerator.Generate(2);

        [Theory(DisplayName = "Filling and submitting registration form")]
        [MemberData(nameof(FormTestData))]
        [AllureDescription("This test verifies that filling in all data in the form is correctly displayed in the Result table")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureTag("Smoke", "Fill Form")]
        [AllureOwner("QA-Team")]
        public async Task FillAndSubmitFormTest(TestFormData data)
        {
            Log.Info("Navigating to Automation Practice Form");

            await _fixture.Page.GotoAsync(FrameworkConfigProvider.Config.BaseUrl);

            AutomationPracticeFormPage formPage = _fixture.PageFactory.FormPage;

            Log.Info("Filling input fields in the Form");

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

            Log.Info("Submiting Form");

            await formPage.SubmitAsync();

            Log.Info("Asserting Result Table's contents");

            SubmitedDataTablePage table = _fixture.PageFactory.SubmitedDataTablePage;

            PracticeFormAssertions.AssertSubmitedData(data, table);

            Log.Info("Closing Result Table's modal panel");

            await table.ClickClose();

            Log.Info("Asserting that the Result Table's modal panel is closed");

            await Expect(table.ResultsModal).Not.ToBeVisibleAsync();
        }

        [Theory(DisplayName = "Filling and submitting registration form with Invalid Data")]
        [MemberData(nameof(FormTestData))]
        [AllureDescription("This test verifies that not filling in required data and incorrect email in the form display errors and the Results Table is not displayed")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureTag("Smoke", "Invalid Form")]
        [AllureOwner("QA-Team")]
        public async Task FillAndSubmitFormWithEmptyRequiredFieldsTest(TestFormData data)
        {
            Log.Info("Navigating to Automation Practice Form");

            await _fixture.Page.GotoAsync(FrameworkConfigProvider.Config.BaseUrl);

            AutomationPracticeFormPage formPage = _fixture.PageFactory.FormPage;

            Log.Info("Filling input fields in the Form");

            await formPage.FillEmailAsync("dsa");
            await formPage.SetDateOfBirthAsync(data.BirthDate);
            await formPage.AddSubjectsAsync(data.Subjects);
            await formPage.SelectHobbiesAsync(data.Hobbies);
            await formPage.FillCurrentAddressAsync(data.CurrentAddress);
            await formPage.SelectStateAsync(data.State);
            await formPage.SelectCityAsync(data.City);

            Log.Info("Submiting Form");

            await formPage.SubmitAsync();

            Log.Info("Asserting Result Table's contents");

            PracticeFormAssertions.AssertInvalidData(formPage);

            Log.Info("Asserting that the Result Table's modal panel is closed");

            await Expect(_fixture.PageFactory.SubmitedDataTablePage.ResultsModal).Not.ToBeVisibleAsync();
        }
    }
}
