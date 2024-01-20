using FluentAssertions;
using OOPsReview;

namespace TDDUnitTestDemo
{
    public class Person_Should
    {
        //Attribute title
        // Fact: one test, test body contains all setup, execution
        //          and evaulation of exection
        // Theory: allows for multiple excutions of the same test
        //          using different data input
        //         to specific the different data input, you will use
        //          the attribute [InlinData(...)] along with the Theory 
        //          attribute

        [Fact]
        public void Create_an_Instance_using_the_Default_Constructor()
        {
            //Arrange (setup area)
            string expectedFirstName = "Unknown";
            string expectedLastName = "Unknown";
            
            //Act (the excution of your test)
            // sut: subject under test
            Person sut = new Person();

            //Assert (the evulation of the results of the Act)
            sut.FirstName.Should().Be(expectedFirstName);
            sut.LastName.Should().Be(expectedLastName);
            sut.residentAddress.Should().BeNull();
            sut.EmploymentPositions.Count().Should().Be(0);
        }
    }
}