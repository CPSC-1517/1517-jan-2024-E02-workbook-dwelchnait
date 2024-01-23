using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
    public class Person
    {
        private string _FirstName;
        public string FirstName 
        {
            get { return _FirstName; } 
            set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("First Name is reqired");
                }
                _FirstName = value.Trim();
            }
        }
        public string LastName { get; set; }
        public ResidentAddress residentAddress { get; set; }
        public List<Employment> EmploymentPositions { get; set; } = new List<Employment>();
        public Person()
        {
            FirstName="Unknown";
            LastName="Unknown";
        }
        public Person(string firstname, string lastname, 
                    ResidentAddress address, List<Employment> employmentpositions)
        {
            
            if (string.IsNullOrWhiteSpace(lastname))
            {
                throw new ArgumentNullException("Last Name is required");
            }
            FirstName = firstname;
            LastName = lastname;
            residentAddress = address;
            if (employmentpositions != null)
            {
                EmploymentPositions = employmentpositions;

            }
        }
    }
}
