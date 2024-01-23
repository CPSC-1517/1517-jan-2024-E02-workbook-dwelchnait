

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

        [Fact]
        public void Create_an_Instance_using_the_Greedy_Constructor_With_No_Employment_List()
        {
            //Arrange (setup area)
            string expectedFirstName = "Unknown";
            string expectedLastName = "Unknown";
            ResidentAddress expectedAddress = new ResidentAddress(12, "Maple St.",
                                        "St. Albert", "AB", "T8Y8U8");

            
            //Act (the excution of your test)
            // sut: subject under test
            Person sut = new Person(expectedFirstName,expectedLastName, expectedAddress, null);

            //Assert (the evulation of the results of the Act)
            sut.FirstName.Should().Be(expectedFirstName);
            sut.LastName.Should().Be(expectedLastName);
            sut.residentAddress.Should().Be(expectedAddress);
            sut.EmploymentPositions.Count().Should().Be(0);
        }

        [Fact]
        public void Create_an_Instance_using_the_Greedy_Constructor_With_Employment_List()
        {
            //Arrange (setup area)
            string expectedFirstName = "Unknown";
            string expectedLastName = "Unknown";
            ResidentAddress expectedAddress = new ResidentAddress(12, "Maple St.",
                                        "St. Albert", "AB", "T8Y8U8");
            List<Employment> positions = Get_Employment_List();

            //Act (the excution of your test)
            // sut: subject under test
            Person sut = new Person(expectedFirstName, expectedLastName, expectedAddress, positions);

            //Assert (the evulation of the results of the Act)
            sut.FirstName.Should().Be(expectedFirstName);
            sut.LastName.Should().Be(expectedLastName);
            sut.residentAddress.Should().Be(expectedAddress);
            sut.EmploymentPositions.Count().Should().Be(3);
        }

        [Fact]
        public void Change_FirstName()
        {
            //Arrange (setup area)
            string FirstName = "Don";
            string LastName = "Welch";
            ResidentAddress Address = new ResidentAddress(12, "Maple St.",
                                        "St. Albert", "AB", "T8Y8U8");
            Person sut = new Person(FirstName, LastName, Address, null);

            string expectedNewFirstName = "Pat";

            //Act
            sut.FirstName = "Pat";

            //Assert
            sut.FirstName.Should().Be(expectedNewFirstName);
        }

        //this annotation will allow for you to specific multiple records of input
        //  to your tests
        //each record of input will execute the test again
        //on the header for this type of testing, you will need to supply an
        //  appropriate list of parameters

        //asumption: firstname and lastname are required
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        public void Throw_ArgumentNullException_Using_the_Greedy_Constructor_on_FirstName(string firstname)
        {
            //Arrange (setup area)
            string LastName = "Welch";
            ResidentAddress Address = new ResidentAddress(12, "Maple St.",
                                        "St. Albert", "AB", "T8Y8U8");


            //Act (the excution of your test)
            // sut: subject under test
            Action action = () => new Person(firstname, LastName, Address, null);

            //Assert (the evulation of the results of the Act)
            action.Should().Throw<ArgumentNullException>();
        }
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        public void Throw_ArgumentNullException_Using_the_Greedy_Constructor_on_LastName(string lastname)
        {
            //Arrange (setup area)
            string FirstName = "Don";
            ResidentAddress Address = new ResidentAddress(12, "Maple St.",
                                        "St. Albert", "AB", "T8Y8U8");


            //Act (the excution of your test)
            // sut: subject under test
            Action action = () => new Person(FirstName, lastname, Address, null);

            //Assert (the evulation of the results of the Act)
            action.Should().Throw<ArgumentNullException>();
        }
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        public void Throw_ArgumentNullException_Using_Changing_FirstName(string firstname)
        {
            //Arrange (setup area)
            string FirstName = "Don";
            string LastName = "Welch";
            ResidentAddress Address = new ResidentAddress(12, "Maple St.",
                                        "St. Albert", "AB", "T8Y8U8");
            Person sut = new Person(FirstName, LastName, Address, null);

            //Act (the excution of your test)
            // sut: subject under test
            Action action = () => sut.FirstName = firstname;

            //Assert (the evulation of the results of the Act)
            action.Should().Throw<ArgumentNullException>();
        }

        private List<Employment> Get_Employment_List()
        {
            List<Employment> positions = new List<Employment>();
            positions.Add(new Employment("PC II", SupervisoryLevel.TeamMember,
                            DateTime.Parse("2013/03/16"), 3.5));
            positions.Add(new Employment("PC III", SupervisoryLevel.TeamMember,
                            DateTime.Parse("2016/09/16"), 1.5));
            positions.Add(new Employment("TL I", SupervisoryLevel.TeamLeader,
                            DateTime.Parse("2018/03/16")));
            return positions;
        }
    }
}