using OOPsReview;
using Microsoft.AspNetCore.Components; //needed for the [Inject]

namespace BlazorWebApp.Components.Pages.Samples
{
    public partial class DataEntry
    {
        private Employment employment = new();
        private string feedback = "";
        //the first string represents the unique key to the dictionary entry
        //the second string represents the context (value) associated with the key
        private Dictionary<string, string> errors = new();

        // this could also have been created by using a simple List collection
        // private List<string> errors = new();

        //declaring my input control variable
        private string employmentTitle = "";
        private SupervisoryLevel supervisoryLevel;
        private DateTime startDate;
        private double empYears = 0;

        //this variable is required if you are using property injection
        //  for services available to your application
        [Inject]
        public IWebHostEnvironment webHostEnvironment { get; set; } = default;

        protected override void OnInitialized()
        {
            //add code to initialize any field you wish overriding
            //   the defaults for that field
            startDate=DateTime.Today;
            base.OnInitialized();
        }

        public void Collect()
        {
            feedback = "";  //delete any old messages
            errors.Clear(); //empties the error message Dictionary

            //primitive validation
            //  presence
            //  datatype
            // range values

            //Business Rules
            //title must be presence, must have at least one character
            //start date cannot be in the future
            //years cannot be less than zero

            if (string.IsNullOrWhiteSpace(employmentTitle))
            {
                //add an error message to the Dictionary collection errors
                //For a Dictionary that has been defined with a key attribute
                //  the key attribute value Must be unique
                errors.Add("Title", "Title is required");
            }
            if (startDate >= DateTime.Today.AddDays(1))
            {
                errors.Add("StartDate", "Start Date is in the future. Must be today or the past.");
            }
            if (empYears < 0)
            {
                errors.Add("Years", "Years must be 0 or greater (1/4 years allowed");
            }
            if (errors.Count == 0)
            {
                try
                {


                    employment = new Employment(employmentTitle,
                                                supervisoryLevel,
                                                startDate,
                                                empYears);

                    //write the class data as a string to a csv text file
                    // required:
                    // a) know the location of the file (name)
                    // b) the technique to use in writing to the file
                    //    there are serveral ways to write to the file
                    //      a) StreamWriter/StreamReader
                    //      b) using the System.IO.File methods
                    //           (handles the streaming of the data)

                    //WARNING: when you use the System.IO.File you MUST use the
                    //          fully qualified naming to the class method you wish\
                    //          to use.
                    //         you can not get by just usinng a reference to the
                    //          namespace at the top of your code (using System.IO;)

                    //there are a couple of ways to refer to your file and its path
                    //  i) obtain the root path of your application using an injection
                    //      service called IWebHostEnvironment via property injection
                    //  ii) use relative addressing starting a the top of your application

                    //in this example we will demonstrate property injection
                    //the method that will be use will return the path from the
                    //  top of your drive to the top of your application
                    //append the remainder part of the file path to this result (via concentation)

                    //WARNING: the folder slash for your path can be both a forward or back slash
                    //              on a PC BUT for an Apple machine, you must use the forwardslash (/)
                    string csvFilePathName = $@"{webHostEnvironment.ContentRootPath}/Data/Employments.csv";

                    //write the data from the employment instance (ToString) as a line to the csv file
                    //since the string does not contain a line feed character, we will need to concatenate
                    //  the character (\n)
                    //the System.IO.File method will be AppendAllText(string)
                    // AppendAllText will
                    //   a) create the file if it does not exist
                    //   b) opens
                    //   c) writes the text
                    //   d) closes
                    string line = $"{employment.ToString()}\n";
                    System.IO.File.AppendAllText(csvFilePathName,line);

                    // feedback to the user
                    feedback ="Data has been saved";
                }
                catch (ArgumentNullException ex)
                {
                    errors.Add("Null Value", GetInnerException(ex).Message);
                }
                catch(ArgumentException ex)
                {
                    errors.Add("Rule Exception", GetInnerException(ex).Message);

                }
                catch (FormatException ex)
                {
                    errors.Add("Invalid Format", GetInnerException(ex).Message);

                }
                catch (Exception ex)
                {
                    errors.Add("System Error", GetInnerException(ex).Message);

                }
            }

        }
        public void Clear()
        {
            feedback = "";  //delete any old messages
            errors.Clear(); //empties the error message Dictionary
            //handle the fields
            employmentTitle="";
            supervisoryLevel = SupervisoryLevel.Entry;
            startDate = DateTime.Today;
            empYears = 0;
        }
        
        public Exception GetInnerException(Exception ex)
        {
            while (ex.InnerException != null)
                ex = ex.InnerException;
            return ex;
        }
    }
}
