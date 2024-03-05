using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
    public class Employment
    {
        #region data member
        //fields, attributes, data members
        //hold a piece of data
        //data is valuable
        //securing access by making them private
        //access and modification will be done via
        // other components of the class
        private string? _Title;
        private double _Years;
        private SupervisoryLevel _Level;

        #endregion
        #region properties
        //a property is associated with a single piece of data
        //properties DO NOT have parameters
        //to refer to the assoicated data lfor the property use
        //  the keyword value
        

        //there are two basic forms for properties: auto implemented
        //and fully implemented

        //fully implemented property
        //why?
        // it allows for additional logic to be included in the
        //      execution of the property
        // a typical use will be to include validation

        //properties will be the doorway into the data that is
        //  contained within the instance of the class
        public string? Title
        {
            //access the data inside the instance
            //return the data member
            get { return _Title; }
            //mutator this alters the data of the instance
            //optional
            //they can be private
            //  if private the data associated with this property
            //  is altered during the constructor or a method
            //  you will NOT be able to alter the property directly
            set
            {
                //business rule
                //Title cannot be empty
                //validate the incoming data value
                if (string.IsNullOrWhiteSpace(value))
                {
                    //NO WRITE COMMAND
                    //use Exceptions
                    throw new ArgumentNullException("Title must be supplied");
                }
                _Title = value;
            }
        }
        public double Years
        {
            //years cannot be negative
            get { return _Years; }
            set
            {
                //this set is public by default
                //the property can appear on the receiving side of an
                //  assignment statement
                //ex     myInstance.Years = .....
                //if (value < 0.0)
                if (!Utilities.IsPositive(value))
                {
                    throw new ArgumentException($"Years {value} is less than 0. Years must be positive");
                }
                _Years = value;
            }
        }
        
        public SupervisoryLevel Level
        {
            get { return _Level; }
            // a private set means that the property
            //      can ONLY be set via code within
            //      the constructor (at time of creation)
            //      OR
            //      via some of code such as a method or
            //          another property
            // you CANNOT have the property on the receiving side
            //      of an assignment statement
            //
            // an advantage of doing this is increasing security
            //      on the field as any change is under the
            //      control of the class
            //
            private set
            {
                // you can validate that an acceptable integer value
                //      was passed into this property
                // syntax:  Enum.IsDefined(typeof(xxxx), value)
                //              where xxx is the enum name
                if (!Enum.IsDefined(typeof(SupervisoryLevel), value))
                {
                    throw new ArgumentException($"Supervisory Level is invalid {value}");
                }
                _Level = value;
            }
        }
        // this property is an example of an auto-implemented property
        // there is no validation within the property
        // there is NO private data member for this property
        //  the system will generate an internal storage area for the data
        //      and handle the setting and getting from that storage
        // auto-implemented properties can have either a public or private set
        // using a public or private set is a design decision
        // the ONLY way to access or set a value from/to the property is
        //      via the property itself
        public DateTime StartDate { get; private set; }


        #endregion
        #region constructors
        //Constructors

        //the purpose of a constructor is to create an instance of your
        //  class in a known state

        //does a class need a constructor? NO
        //  if a class does NOT have a constructor then the system will
        //      create the instance and assign the system default value to data
        //      member and/or auto implemented property
        //  if you have no constructor the common phrase is "using a system constructor"

        //IF YOU CODE A CONSTRUCTOR IN YOUR CLASS YOU ARE RESPONSIBLE FOR ANY AND ALL
        //  CONSTRUCTORS FOR THE CLASS!!!

        // default constructor
        //you can apply your own literal values for your data memebers and/or auto-implemented
        //  properties that differ from the system default values
        //why?
        //  you may have data that is validated and using the system default values that would
        //  cause an exception

        //constructors DO NOT have a return datatype in their header definition
        //constructors CANNOT be called directly by an developer logic
        //constructors are referenced (called) indirectly by using the "new" command

        public Employment()
        {
            Title = "Unknown";
            //by default the Level will get the 1st value of the Enum
            Level = SupervisoryLevel.TeamMember;
            StartDate = DateTime.Today;
        }

        //greedy constructor

        //a greedy constructor is one that accepts a parameter list of values
        //  to assign to your instance data on creation of the instance
        //generally your greedy constructor constaints a parameter on the signature
        //  for each data member/auto-implemented property in your class definition

        //if you have any default values for your parameters, the default parameters
        //  must appear AFTER the non-default parameters in the parameter list
        //in this example we will default Years to 0

        public Employment(string? title, SupervisoryLevel level, DateTime startdate,
                            double years = 0.0)
        {
            Title = title;
            Level = level;

            //you can add logic to your constructor to ensure that the incoming value
            //  is valid
            //this is useful for auto-implemented properties
            //this is useful for private sets which do not contain validation code

            //in this example we will ensure that the startdate is not a day in the future
            if(startdate >= DateTime.Today.AddDays(1))
            {
                throw new ArgumentException($"The start dagte {startdate} is in the future.");
            }
            StartDate = startdate;

            //one can do additional logic to adjust your starting values
            //ensure that years is appropriate for the entered startdate
            if (years > 0.0)
            {
                Years = years;
            }
            else
            {
                TimeSpan span = DateTime.Now - startdate;
                Years = Math.Round((span.Days / 365.25), 1);
            }
        }
        #endregion
        #region methods (aka behaviours)

        //method syntax:  accesslevel [override][static] rdt methodname ([list of parameters])
        //                  { ...... }

        //you may wish to dump the contents of your instance in a string
        //you can override the basic class method of ToString() and create your
        //   own version of the string
        public override string ToString()
        {
            //if this is a csv string then there could be a problem using the date
            //you may wish it to be in a certain format
            //ex Project Leader II,TeamLeader,Sep 11,2010,13.4 note that comma in the date will be a problem
            //   to correct remove the , out of the date format
            //   Project Leader II,TeamLeader,Sep 11 2010,13.4
            return $"{Title},{Level},{StartDate.ToString("MMM dd yyyy")},{Years.ToString()}";
        }

        //we wish a method to alter a private set
        //the property Level has a private set
        //therefore the only ways to assign a value to the property
        //  is via a) constructor, b) another property, or c) a method

        //what about validation?
        //validation can be done in multiple places
        //  a) can it be done in this method?   Yes
        //  b) can it be done within the property? Yes if the property if fully-implemented
        public void SetEmploymentResponsibilityLevel(SupervisoryLevel level)
        {
            //property contains validation
            Level = level;
        }
        //Property StartDate is auto-implementd
        //Property StartDate has NO validation
        //If you need to do any validation on the incoming value
        //  you will need to do the validation in the method
        //in this example we will ensure that the startdate is not a day in the future
        //here we will need to duplicate the validation of the data using the same code
        //  in the constructor
        public void CorrectStartDate(DateTime startdate)
        {
            if (startdate >= DateTime.Today.AddDays(1))
            {
                throw new ArgumentException($"The start dagte {startdate} is in the future.");
            }
            StartDate = startdate;
        }
        public double UpdateCurrentEmploymentYearsExperience()
        {
            TimeSpan span = DateTime.Now - StartDate;
            Years = Math.Round((span.Days / 365.25), 1);
            return Years;
        }

        //Parsing(string)

        //attempts to change the contents of a string to another datatype

        //parsing for this class assumes the passed string will resemble the
        //  greedy constructor: having sufficient values to pass to the greedy
        //  constructor
        //this method contains basic validation on the number of fields
        //  if there are insufficient values then expected an error can be thrown
        //example
        //    string 55 --> int x = int.Parse(string); <-- success
        //           bob --> int x = int.Parse(string); <-- abort with a message

        //if this can be done on an int class why not on our Employment class?
        //we will need to add a method (Parse) that receives a string
        //  the string will need to have sufficient values to create a proper Employment

        //this method needs to be able to be called without an instance of Employment
        //  in existence
        //therefore the method will be a static method
        public static Employment Parse(string item)
        {
            //test is a string of csv values (comma separated values)
            //   note you could use some other delimator
            //separate the string of values into individual string values
            //      create an array of strings resulting from using .Split(delimator)
            string[] pieces = item.Split(',');

            //verify that sufficient and correct number of values exist to
            //  create the Employment instance
            //if not throw an exception (FormatException)
            if (pieces.Length != 4)
            {
                throw new FormatException($"String not in expected format. Missing/excessive values(s): {item}");
            }


            //return an instance of Employment
            //the instance will be created by the separate pieces
            //the pieces will be converted if required using the appropriate parsing
            return new Employment(pieces[0],
                                (SupervisoryLevel)Enum.Parse(typeof(SupervisoryLevel), pieces[1]),
                                DateTime.Parse(pieces[2]),
                                double.Parse(pieces[3]));
        }

        //the TryParse method will receive a string AND output an instance of
        //  Employment as an output parameter AND return a boolean success value

        //syntax:   .TryParse    xxxx.TryParse(string, out datatype parametername)
        //example   int.TryParse   int.TryParse(inputValue, out int myIntegerNumber)

        //the method will return a boolean value indicating success
        //to avoid duplicate code; this method will call .Parse()

        public static bool TryParse(string item, out Employment result)
        {
            result= null;
            bool valid = true;
            try
            {
                result = Parse(item);
            }
            //catch(FormatException ex)
            //{
            //    valid = false;
            //}
            catch (Exception ex)
            {
                valid = false;
            }
            return valid;
        }
        #endregion
    }
}
