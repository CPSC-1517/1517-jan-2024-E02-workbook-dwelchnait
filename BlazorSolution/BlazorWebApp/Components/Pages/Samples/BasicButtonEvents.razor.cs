namespace BlazorWebApp.Components.Pages.Samples
{
    public partial class BasicButtonEvents
    {
        private string inputValue;  //this is tied to the input control via @bind
        private string feedback; //this will be used to display information

        //create a method that will be executed in response to pressing the
        //   button that has on onclick parameter pointing to this method
        private void OnClickMethodName()
        {
            //the data entered into the input control will be placed
            //  for me into the local variable feedback
            //this method will move the inputed value into my output variable
            feedback = $"You entered >{inputValue}<";

        }
        private void OnClickHeadsOrTails()
        {
            Random rdn = new Random();
            int flip = rdn.Next(1, 101);
            if (flip % 2 == 0)
            {
                feedback = "Coin flipped Heads";
            }
            else
            {
                feedback = "Coin flipped Tails";
            }

        }

        //there are special events already created for the blazor component
        //the OnInitialized() method, you can alter the display of controls
        //  and your variable by executing your own code
        protected override void OnInitialized()
        {
            feedback = "OnInitialization code";
            base.OnInitialized();
        }

    }
}
