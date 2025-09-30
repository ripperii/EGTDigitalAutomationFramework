using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGTDigitalAutomationFramework.Models
{
    public class TestFormData
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Gender { get; set; }
        public required string Mobile { get; set; }
        public required string BirthDate { get; set; }
        public required List<string> Subjects { get; set; }
        public required List<string> Hobbies { get; set; }
        public required string CurrentAddress { get; set; }
        public required string State { get; set; }
        public required string City { get; set; }
    }
}
