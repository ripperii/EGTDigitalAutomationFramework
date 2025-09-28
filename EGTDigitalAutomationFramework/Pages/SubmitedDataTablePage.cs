using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace EGTDigitalAutomationFramework.Pages
{
    public class SubmitedDataTablePage(IPage page)
    {
        string xpath = @"//tbody//tr[
                td[count(//thead/tr//th[normalize-space(.)='{0}']/preceding-sibling::th)+1]
                [normalize-space(.)='{1}']
                ]/td[count(//thead/tr//th[normalize-space(.)='{2}']/preceding-sibling::th)+1]";

        private ILocator NameField => page.Locator(string.Format(xpath,"Label", "Student Name", "Values"));
        private ILocator EmailField => page.Locator(string.Format(xpath, "Label", "Student Email", "Values"));
        private ILocator GenderField => page.Locator(string.Format(xpath, "Label", "Gender", "Values"));
        private ILocator MobileField => page.Locator(string.Format(xpath, "Label", "Mobile", "Values"));
        private ILocator DateOfBirthField => page.Locator(string.Format(xpath, "Label", "Date of Birth", "Values"));
        private ILocator SubjectsField => page.Locator(string.Format(xpath, "Label", "Subjects", "Values"));
        private ILocator HobbiesField => page.Locator(string.Format(xpath, "Label", "Hobbies", "Values"));
        private ILocator PictureField => page.Locator(string.Format(xpath, "Label", "Picture", "Values"));
        private ILocator AddressField => page.Locator(string.Format(xpath, "Label", "Address", "Values"));
        private ILocator StateAndCityField => page.Locator(string.Format(xpath, "Label", "State and City", "Values"));
        private ILocator CloseButton => page.Locator("#closeLargeModal");

        public async Task<string> GetName()
        {
            return await NameField.InnerTextAsync();
        }
        public async Task<string> GetEmail()
        {
            return await EmailField.InnerTextAsync();
        }
        public async Task<string> GetGender()
        {
            return await GenderField.InnerTextAsync();
        }
        public async Task<string> GetMobile()
        {
            return await MobileField.InnerTextAsync();
        }
        public async Task<string> GetDateOfBirth()
        {
            return await DateOfBirthField.InnerTextAsync();
        }
        public async Task<string> GetSubjects()
        {
            return await SubjectsField.InnerTextAsync();
        }
        public async Task<string> GetHobbies()
        {
            return await HobbiesField.InnerTextAsync();
        }
        public async Task<string> GetAddress()
        {
            return await AddressField.InnerTextAsync();
        }
        public async Task<string> GetStateAndCity()
        {
            return await StateAndCityField.InnerTextAsync();
        }
        public async Task ClickClose()
        {
            await CloseButton.ClickAsync();
        }
    }
}
