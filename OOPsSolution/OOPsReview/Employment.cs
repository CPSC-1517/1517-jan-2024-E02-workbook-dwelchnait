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
                if (value < 0.0)
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
        #endregion
        #region methods (aka behaviours)
        #endregion
    }
}
