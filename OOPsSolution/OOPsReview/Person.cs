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
        private string _LastName;
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
        public string LastName
        {
            get { return _LastName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Last Name is reqired");
                }
                _LastName = value.Trim();
            }
        }
        public ResidentAddress residentAddress { get; set; }
        public List<Employment> EmploymentPositions { get; set; } = new List<Employment>();
       //readonly property that returns the person's fullname in the form last, first
        //public string FullName { get { return $"{LastName}, {FirstName}"; } }
        public string FullName => $"{LastName}, {FirstName}";
        public Person()
        {
            FirstName="Unknown";
            LastName="Unknown";
        }
        public Person(string firstname, string lastname, 
                    ResidentAddress address, List<Employment> employmentpositions)
        {
            FirstName = firstname;
            LastName = lastname;
            residentAddress = address;
            if (employmentpositions != null)
            {
                EmploymentPositions = employmentpositions;
            }
        }
        //ChangeFullName(firstname, lastname)
        public void ChangeFullName(string firstname, string lastname)
        {
            FirstName = firstname;
            LastName = lastname;
        }

        //add an Employee instance to the EmploymentPostions
        //parameters will be an Employment instance
        //instance must exist
        public void AddEmployment(Employment employment)
        {
            if(employment == null)
            {
                throw new ArgumentNullException("Missing employment data.");
            }
            EmploymentPositions.Add(employment);
        }
    }
}
