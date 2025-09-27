using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGTDigitalAutomationFramework.Pages
{
    public class AutomationPracticeFormPage
    {
        private readonly IPage _page;

        public AutomationPracticeFormPage(IPage page)
        {
            _page = page;
        }

        // URL
        public string Url => "https://demoqa.com/automation-practice-form";

        // Locators (you can refine selectors as needed)
        private ILocator FirstNameInput => _page.Locator("#firstName");
        private ILocator LastNameInput => _page.Locator("#lastName");
        private ILocator EmailInput => _page.Locator("#userEmail");
        private ILocator GenderRadio(string gender) => _page.Locator($"//label[text()='{gender}']");
        private ILocator MobileInput => _page.Locator("#userNumber");
        private ILocator DateOfBirthInput => _page.Locator("#dateOfBirthInput");
        private ILocator SubjectsInput => _page.Locator("#subjectsInput");
        private ILocator HobbiesCheckbox(string hobby) => _page.Locator($"//label[text()='{hobby}']");
        private ILocator UploadPictureInput => _page.Locator("#uploadPicture");
        private ILocator CurrentAddressInput => _page.Locator("#currentAddress");
        private ILocator StateDropdown => _page.Locator("#state");
        private ILocator CityDropdown => _page.Locator("#city");
        private ILocator SubmitButton => _page.Locator("#submit");

        public async Task<AutomationPracticeFormPage> NavigateAsync()
        {
            await _page.GotoAsync(Url);
            return this;
        }

        public async Task<AutomationPracticeFormPage> FillFirstNameAsync(string firstName)
        {
            await FirstNameInput.FillAsync(firstName);
            return this;
        }

        public async Task<AutomationPracticeFormPage> FillLastNameAsync(string lastName)
        {
            await LastNameInput.FillAsync(lastName);
            return this;
        }

        public async Task<AutomationPracticeFormPage> FillEmailAsync(string email)
        {
            await EmailInput.FillAsync(email);
            return this;
        }

        public async Task<AutomationPracticeFormPage> SelectGenderAsync(string gender)
        {
            await GenderRadio(gender).ClickAsync();
            return this;
        }

        public async Task<AutomationPracticeFormPage> FillMobileAsync(string mobile)
        {
            await MobileInput.FillAsync(mobile);
            return this;
        }

        public async Task<AutomationPracticeFormPage> SetDateOfBirthAsync(string dateText /* e.g. "15 May 1990" or "15-05-1990" depending on widget */)
        {
            await DateOfBirthInput.ClickAsync();
            // For simplicity, just fill it; sometimes the date picker widget may require more complex interactions
            await DateOfBirthInput.FillAsync(dateText);
            await DateOfBirthInput.PressAsync("Enter");
            return this;
        }

        public async Task<AutomationPracticeFormPage> AddSubjectAsync(string subject)
        {
            await SubjectsInput.FillAsync(subject);
            await SubjectsInput.PressAsync("Enter");
            return this;
        }

        public async Task<AutomationPracticeFormPage> SelectHobbyAsync(string hobby)
        {
            await HobbiesCheckbox(hobby).ClickAsync();
            return this;
        }

        public async Task<AutomationPracticeFormPage> UploadPictureAsync(string filePath)
        {
            await UploadPictureInput.SetInputFilesAsync(filePath);
            return this;
        }

        public async Task<AutomationPracticeFormPage> FillCurrentAddressAsync(string address)
        {
            await CurrentAddressInput.FillAsync(address);
            return this;
        }

        public async Task<AutomationPracticeFormPage> SelectStateAsync(string state)
        {
            await StateDropdown.ClickAsync();
            await _page.Locator($"//div[contains(@id, 'react-select') and text() = '{state}']").ClickAsync();
            return this;
        }

        public async Task<AutomationPracticeFormPage> SelectCityAsync(string city)
        {
            await CityDropdown.ClickAsync();
            await _page.Locator($"//div[contains(@id, 'react-select') and text() = '{city}']").ClickAsync();
            return this;
        }

        public async Task SubmitAsync()
        {
            // The form’s submit button might be beneath fixed footer; scroll or force
            await SubmitButton.ClickAsync(new LocatorClickOptions { Force = true });
        }
    }
}
