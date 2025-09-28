using Bogus;
using EGTDigitalAutomationFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGTDigitalAutomationFramework.Utilities
{
    public static class FormTestDataGenerator
    {
        private static readonly string[] subjects = ["Maths", "Physics", "Chemistry", "Commerce", "Accounting", "Biology", "Economics", "Civics", "English"];
        private static readonly string[] hobbies = ["Sports", "Reading", "Music"];
        private static readonly string[] items = ["Male", "Female", "Other"];
        private static readonly Dictionary<string, List<string>> StateCityMap = new()
        {
            { "NCR", new List<string> { "Delhi", "Gurgaon", "Noida" } },
            { "Uttar Pradesh", new List<string> { "Agra", "Lucknow", "Merrut" } },
            { "Haryana", new List<string> { "Karnal", "Panipat" } },
            { "Rajasthan", new List<string> { "Jaipur", "Jaiselmer" } }
        };

        public static TheoryData<TestFormData> Generate(int count = 5)
        {
            Faker<TestFormData> faker = new Faker<TestFormData>()
                .RuleFor(f => f.FirstName, f => f.Name.FirstName())
                .RuleFor(f => f.LastName, f => f.Name.LastName())
                .RuleFor(f => f.Email, (f, u) => f.Internet.Email(u.FirstName, u.LastName))
                .RuleFor(f => f.Gender, f => f.PickRandom(items))
                .RuleFor(f => f.Mobile, f => f.Phone.PhoneNumber("##########"))
                .RuleFor(f => f.BirthDate, f => f.Date.Past(40, DateTime.Today.AddYears(-18)).ToString("dd MMM yyyy"))
                .RuleFor(f => f.Subjects, f => f.Random.ListItems(subjects, 1))
                .RuleFor(f => f.Hobbies, f => f.Random.ListItems(hobbies, 2))
                .RuleFor(f => f.CurrentAddress, f => f.Address.FullAddress())
                .RuleFor(f => f.State, f => f.PickRandom<string>(StateCityMap.Keys))
                .RuleFor(f => f.City, (faker, model) => faker.PickRandom<string>(StateCityMap[model.State]));

            TheoryData<TestFormData> data = [];

            for (int i = 0; i < count; i++)
            {
                data.Add(faker.Generate());
            }

            return data;
        }
    }
}
