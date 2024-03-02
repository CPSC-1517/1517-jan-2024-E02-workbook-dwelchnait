using OOPsReview;
using System.Diagnostics.Eventing.Reader;

namespace BlazorWebApp.Components.Pages.Samples
{
    public partial class EmployeeReport
    {
        private string feedback = "";
        private List<string> errors = new List<string>();
        private Employment employment = new();
        private List<Employment> employments;

        protected override async Task OnInitializedAsync()
        {
            // Simulate asynchronous loading to demonstrate streaming rendering
            //mimic a large file being read
            //pause 5 seconds
            await Task.Delay(2000);

            Reading();

            //this return is not need due to the fact that this method
            //      is an async Task method
            //return base.OnInitializedAsync();

        }

        void Reading()
        {
            feedback = "";
            errors.Clear();
            employments = new List<Employment>();

            //This addressing of the required file will use relative addressing
            //      starting at the top of your web application
            //string fileName = @"./Data/Employments.csv";
            string fileName = @"./Data/EmploymentsBad.csv";

            // The System.IO.File method ReadAllLines(...) will return an array
            //      of lines as strings where each array element represents a
            //      line in my file
            Array userdata = null;
            // can something go wrong with reading the file
            // a) file not found
            // b) an other system error that occurs

            // if you were using a Dictionary then you might
            //      wish to use a counter to indicate the line number
            //      being processed
            int lineNum = 0;
            try
            {
                //use the ReadAllLines
                userdata = System.IO.File.ReadAllLines(fileName);
             
                //the records are strings
                //Employment is a class being use to create a collection of records
                foreach (string line in userdata)
                {
                    try
                    {
                        lineNum++;
                        employment = Employment.Parse(line);
                        employments.Add(employment);
                    }
                    catch (Exception ex)
                    {
                        // Dictionary: need a unique key for each error
                        //errors.Add($"Line {lineNum}", GetInnerException(ex).Message); 
                        errors.Add($"Record {lineNum} error:" + GetInnerException(ex).Message);

                    }
                }
            }
            catch(Exception ex)
            {
                // Dictionary: need a unique key for each error
                //errors.Add($"Line {lineNum}", GetInnerException(ex).Message); 
                errors.Add($"System Error:" + GetInnerException(ex).Message);

            }
            if (employments.Count > 0)
            {
                feedback = $"There are {employments.Count} lines";
            }
        }
        public Exception GetInnerException(Exception ex)
        {
            while (ex.InnerException != null)
                ex = ex.InnerException;
            return ex;
        }

    }


}
