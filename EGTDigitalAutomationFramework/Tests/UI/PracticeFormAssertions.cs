using Allure.Xunit.Attributes.Steps;
using EGTDigitalAutomationFramework.Models;
using EGTDigitalAutomationFramework.Pages;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGTDigitalAutomationFramework.Tests.UI
{
    internal class PracticeFormAssertions
    {
        public static void AssertSubmitedData(TestFormData expected, SubmitedDataTablePage tablePage)
        {
            using (new FluentAssertions.Execution.AssertionScope())
            {
                tablePage.GetName().Result.Should().Be(expected.FirstName + " " + expected.LastName);
                tablePage.GetEmail().Result.Should().Be(expected.Email);
                tablePage.GetGender().Result.Should().Be(expected.Gender);
                tablePage.GetMobile().Result.Should().Be(expected.Mobile);
                tablePage.GetDateOfBirth().Result.Should().Be(DateTime.ParseExact(expected.BirthDate, "dd MMM yyyy", CultureInfo.InvariantCulture)
                    .ToString("dd MMMM,yyyy", CultureInfo.InvariantCulture));

                tablePage.GetSubjects().Result.Split(", ").Should().HaveCount(expected.Subjects.Count)
                    .And.Contain(expected.Subjects);

                tablePage.GetHobbies().Result.Split(", ").Should().HaveCount(expected.Hobbies.Count)
                    .And.Contain(expected.Hobbies);

                tablePage.GetAddress().Result.Should().Be(expected.CurrentAddress);
                tablePage.GetStateAndCity().Result.Should().Be(expected.State + " " + expected.City);
            }
        }
        public static void AssertInvalidData(AutomationPracticeFormPage formPage)
        {
            using (new FluentAssertions.Execution.AssertionScope())
            {
                formPage.ValidateFirstNameRequiredAsync().Result.Should().BeTrue();
                formPage.ValidateLastNameRequiredAsync().Result.Should().BeTrue();
                formPage.ValidateEmailIsCorrectAsync().Result.Should().BeTrue();
                formPage.ValidateMobileNumberRequiredAsync().Result.Should().BeTrue();
                formPage.ValidateGenderRequiredAsync("Male").Result.Should().BeTrue();
                formPage.ValidateGenderRequiredAsync("Female").Result.Should().BeTrue();
                formPage.ValidateGenderRequiredAsync("Other").Result.Should().BeTrue();

            }
        }

    }
}
