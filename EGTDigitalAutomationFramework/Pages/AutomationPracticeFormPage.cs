using Allure.Xunit.Attributes.Steps;
using EGTDigitalAutomationFramework.Configs;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGTDigitalAutomationFramework.Pages
{
    public class AutomationPracticeFormPage(IPage page)
    {
        private ILocator FirstNameInput => page.Locator("#firstName");
        private ILocator LastNameInput => page.Locator("#lastName");
        private ILocator EmailInput => page.Locator("#userEmail");
        private ILocator GenderRadio(string gender) => page.Locator($"//label[text()='{gender}']");
        private ILocator GenderRadioButton(string gender) => page.Locator($"//input[@value='{gender}']");
        private ILocator MobileInput => page.Locator("#userNumber");
        private ILocator DateOfBirthInput => page.Locator("#dateOfBirthInput");
        private ILocator SubjectsInput => page.Locator("#subjectsInput");
        private ILocator HobbiesCheckbox(string hobby) => page.Locator($"//label[text()='{hobby}']");
        private ILocator UploadPictureInput => page.Locator("#uploadPicture");
        private ILocator CurrentAddressInput => page.Locator("#currentAddress");
        private ILocator StateDropdown => page.Locator("#state");
        private ILocator CityDropdown => page.Locator("#city");
        private ILocator SubmitButton => page.Locator("#submit");

        [AllureStep("Fill First Name with value: {0}")]
        public async Task<AutomationPracticeFormPage> FillFirstNameAsync(string firstName)
        {
            await FirstNameInput.FillAsync(firstName);
            return this;
        }

        [AllureStep("Fill Last Name with value: {0}")]
        public async Task<AutomationPracticeFormPage> FillLastNameAsync(string lastName)
        {
            await LastNameInput.FillAsync(lastName);
            return this;
        }

        [AllureStep("Fill Email with value: {0}")]
        public async Task<AutomationPracticeFormPage> FillEmailAsync(string email)
        {
            await EmailInput.FillAsync(email);
            return this;
        }

        [AllureStep("Select Gender with value: {0}")]
        public async Task<AutomationPracticeFormPage> SelectGenderAsync(string gender)
        {
            await GenderRadio(gender).ClickAsync();
            return this;
        }

        [AllureStep("Fill Mobile with value: {0}")]
        public async Task<AutomationPracticeFormPage> FillMobileAsync(string mobile)
        {
            await MobileInput.FillAsync(mobile);
            return this;
        }

        [AllureStep("Set Date of Birth to value: {0}")]
        public async Task<AutomationPracticeFormPage> SetDateOfBirthAsync(string dateText /* e.g. "15 May 1990" or "15-05-1990" depending on widget */)
        {
            await DateOfBirthInput.ClickAsync();
            // For simplicity, just fill it; sometimes the date picker widget may require more complex interactions
            await DateOfBirthInput.FillAsync(dateText);
            await DateOfBirthInput.PressAsync("Enter");
            return this;
        }

        [AllureStep("Add Subject: {0}")]
        public async Task<AutomationPracticeFormPage> AddSubjectAsync(string subject)
        {
            await SubjectsInput.FillAsync(subject);
            await SubjectsInput.PressAsync("Enter");
            return this;
        }

        [AllureStep("Add subjects: {0}")]
        public async Task<AutomationPracticeFormPage> AddSubjectsAsync(List<string> subjects)
        {
            foreach (string subject in subjects)
            {
                await SubjectsInput.FillAsync(subject);
                await page.Locator($"//div[contains(@id, 'react-select') and text() = '{subject}']").ClickAsync();
            }

            return this;
        }

        [AllureStep("Select Hobby: {0}")]
        public async Task<AutomationPracticeFormPage> SelectHobbyAsync(string hobby)
        {
            await HobbiesCheckbox(hobby).ClickAsync();
            return this;
        }

        [AllureStep("Select Hobbies: {0}")]
        public async Task<AutomationPracticeFormPage> SelectHobbiesAsync(List<string> hobbies)
        {
            foreach (string hobby in hobbies)
            {
                await HobbiesCheckbox(hobby).ClickAsync();
            }

            return this;
        }
        [AllureStep("Upload Picture: {0}")]
        public async Task<AutomationPracticeFormPage> UploadPictureAsync(string filePath)
        {
            await UploadPictureInput.SetInputFilesAsync(filePath);
            return this;
        }
        [AllureStep("Fill Current Address with value: {0}")]
        public async Task<AutomationPracticeFormPage> FillCurrentAddressAsync(string address)
        {
            await CurrentAddressInput.FillAsync(address);
            return this;
        }

        [AllureStep("Select State: {0}")]
        public async Task<AutomationPracticeFormPage> SelectStateAsync(string state)
        {
            await StateDropdown.ClickAsync();
            await page.Locator($"//div[contains(@id, 'react-select') and text() = '{state}']").ClickAsync();
            return this;
        }

        [AllureStep("Select City: {0}")]
        public async Task<AutomationPracticeFormPage> SelectCityAsync(string city)
        {
            await CityDropdown.ClickAsync();
            await page.Locator($"//div[contains(@id, 'react-select') and text() = '{city}']").ClickAsync();
            return this;
        }

        [AllureStep("Click Submit button")]
        public async Task SubmitAsync()
        {
            // The form’s submit button might be beneath fixed footer; scroll or force
            await SubmitButton.ClickAsync(new LocatorClickOptions { Force = true });
        }

        [AllureStep("Validate First Name is required")]
        public async Task<bool> ValidateFirstNameRequiredAsync()
        {
            return await FirstNameInput.EvaluateAsync<bool>("el => el.matches(':invalid')");
        }

        [AllureStep("Validate Last Name is required")]
        public async Task<bool> ValidateLastNameRequiredAsync()
        {
            return await LastNameInput.EvaluateAsync<bool>("el => el.matches(':invalid')");
        }

        [AllureStep("Validate Mobile Number is required")]
        public async Task<bool> ValidateMobileNumberRequiredAsync()
        {
            return await MobileInput.EvaluateAsync<bool>("el => el.matches(':invalid')");
        }

        [AllureStep("Validate Gender selection is required")]
        public async Task<bool> ValidateGenderRequiredAsync(string gender)
        {
            return await GenderRadioButton(gender).EvaluateAsync<bool>("el => el.matches(':invalid')");
        }
        [AllureStep("Validate Email is correct")]
        public async Task<bool> ValidateEmailIsCorrectAsync()
        {
            return await EmailInput.EvaluateAsync<bool>("el => el.matches(':invalid')");
        }
    }
}
