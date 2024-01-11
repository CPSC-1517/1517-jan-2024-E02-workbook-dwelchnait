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
        public string Title
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
                if (value < 0.0)
                {
                    throw new ArgumentException($"Years {value} is less than 0. Years must be positive");
                }
                _Years = value;
            }
        }
        
        #endregion
        #region constructors
        #endregion
        #region methods (aka behaviours)
        #endregion
    }
}
