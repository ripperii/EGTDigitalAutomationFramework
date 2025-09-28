using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGTDigitalAutomationFramework.Models
{
    public class TestFormData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Mobile { get; set; }
        public string BirthDate { get; set; }
        public List<string> Subjects { get; set; }
        public List<string> Hobbies { get; set; }
        public string CurrentAddress { get; set; }
        public string State { get; set; }
        public string City { get; set; }
    }
}
