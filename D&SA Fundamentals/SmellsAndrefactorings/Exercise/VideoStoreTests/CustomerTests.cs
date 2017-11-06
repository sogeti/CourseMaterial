using FluentAssertions;
using VideoStoreStart;
using Xunit;

namespace VideoStoreTests
{
    public class CustomerTests
    {

        [Fact]
        public void Statement_WhenHavingAChildrenMovieForADay_ShouldProduceAppropriateStatement()
        {
            // Arrange
            var customer = new Customer("John Doe");
            customer.AddRental(new Rental(new Movie("Cars", Movie.PriceCode.CHILDRENS),1));
            // Act
            string statement = customer.Statement();
            // Assert
            statement.Should().Be("Rental Record for John Doe.\n\tCars\t1,5$\nAmount owed is 1,5$.\nYou earned 1 frequent renter points.");
        }

        [Fact]
        public void Statement_WhenHavingAChildrenMovieForTwoDays_ShouldProduceAppropriateStatement()
        {
            // Arrange
            var customer = new Customer("John Doe");
            customer.AddRental(new Rental(new Movie("Cars",Movie.PriceCode.CHILDRENS),2));
            // Act
            string statement = customer.Statement();
            // Assert
            statement.Should().Be("Rental Record for John Doe.\n\tCars\t1,5$\nAmount owed is 1,5$.\nYou earned 1 frequent renter points.");
        }

        [Theory]
        [InlineData(4, "3$")]
        [InlineData(5, "4,5$")]
        [InlineData(6, "6$")]
        public void Statement_WhenHavingAChildrenMovieForMoreThanThreeDays_ShouldPenalizeWithOneAndAHalfDollarsPerExtraDay(int daysRented, string amountOwed)
        {
            // Arrange
            var customer = new Customer("John Doe");
            customer.AddRental(new Rental(new Movie("Cars",Movie.PriceCode.CHILDRENS),daysRented));
            // Act
            string statement = customer.Statement();
            // Assert
            statement.Should().Be(string.Format("Rental Record for John Doe.\n\tCars\t{0}\nAmount owed is {0}.\nYou earned 1 frequent renter points.", amountOwed));
        }

        [Fact]
        public void Statement_WhenHavingTwoChildrenMovies_ShouldGetTwoFrequentRenterPoints()
        {
            // Arrange
            var customer = new Customer("John Doe");
            customer.AddRental(new Rental(new Movie("Cars",Movie.PriceCode.CHILDRENS),1));
            customer.AddRental(new Rental(new Movie("Cars 2",Movie.PriceCode.CHILDRENS),1));
            // Act
            string statement = customer.Statement();
            // Assert
            statement.Should().Be("Rental Record for John Doe.\n\tCars\t1,5$\n\t" +
                                              "Cars 2\t1,5$\nAmount owed is 3$.\nYou earned 2 frequent renter points.");
        }

        [Fact]
        public void Statement_WhenHavingANormalMovieForADay_ShouldProduceAppropriateStatement()
        {
            // Arrange
            var customer = new Customer("John Doe");
            customer.AddRental(new Rental(new Movie("Johnny Mnemonic",Movie.PriceCode.REGULAR),1));
            // Act
            string statement = customer.Statement();
            // Assert
            statement.Should().Be("Rental Record for John Doe.\n\tJohnny Mnemonic\t2$\nAmount owed is 2$.\nYou earned 1 frequent renter points.");
        }

        [Theory]
        [InlineData(3, "3,5$")]
        [InlineData(4, "5$")]
        [InlineData(5, "6,5$")]
        public void Statement_WhenHavingANormalMovieMoreThanTwoDays_ShouldPenalizeWithOneAndAnExtraDollarPerExtraDay(int daysRented, string amountOwed)
        {
            // Arrange
            var customer = new Customer("John Doe");
            customer.AddRental(new Rental(new Movie("Johnny Mnemonic",Movie.PriceCode.REGULAR), daysRented));
            // Act
            string statement = customer.Statement();
            // Assert
            statement.Should().Be(string.Format("Rental Record for John Doe.\n\tJohnny Mnemonic\t{0}\nAmount owed is {0}.\nYou earned 1 frequent renter points.", amountOwed));
        }

        [Fact]
        public void Statement_WhenHavingTwoNormalMovies_ShouldGetTwoFrequentRenterPoints()
        {
            // Arrange
            var customer = new Customer("John Doe");
            customer.AddRental(new Rental(new Movie("Johnny Mnemonic", Movie.PriceCode.REGULAR), 1));
            customer.AddRental(new Rental(new Movie("Terminator 2",Movie.PriceCode.REGULAR),1));
            // Act
            string statement = customer.Statement();    
            // Assert
            statement.Should().Be("Rental Record for John Doe.\n\tJohnny Mnemonic\t2$\n\tTerminator 2\t2$\nAmount owed is 4$.\nYou earned 2 frequent renter points.");
        }

        [Fact]
        public void Statement_WhenHavingANewReleaseMovieForADay_ShouldProduceAppropriateStatement()
        {
            // Arrange
            var customer = new Customer("John Doe");
            customer.AddRental(new Rental(new Movie("Skyfall",Movie.PriceCode.NEW_RELEASE),1));
            // Act
            string statement = customer.Statement();
            // Assert
            statement.Should().Be("Rental Record for John Doe.\n\tSkyfall\t3$\nAmount owed is 3$.\nYou earned 1 frequent renter points.");
        }

        [Theory]
        [InlineData(2, "6$")]
        [InlineData(3, "9$")]
        [InlineData(4, "12$")]
        public void Statement_WhenHavingANewReleaseMovieForMoreThanADay_ShouldPenalizeWithThreeDollarsPerDay(int daysRented, string amountOwed)
        {
            // Arrange
            var customer = new Customer("John Doe");
            customer.AddRental(new Rental(new Movie("Skyfall",Movie.PriceCode.NEW_RELEASE),daysRented));
            // Act
            string statement = customer.Statement();
            // Assert
            statement.Should().Be(string.Format("Rental Record for John Doe.\n\tSkyfall\t{0}\nAmount owed is {0}.\nYou earned 2 frequent renter points.", amountOwed));
        }

        [Fact]
        public void Statement_WhenHavingANewReleaseMovieForMoreThanADay_ShouldGetAnExtraFrequentRenterPoint()
        {
            // Arrange
            var customer = new Customer("John Doe");
            customer.AddRental(new Rental(new Movie("Skyfall",Movie.PriceCode.NEW_RELEASE),2));
            // Act
            string statement = customer.Statement();
            // Assert
            statement.Should().Be("Rental Record for John Doe.\n\tSkyfall\t6$\nAmount owed is 6$.\nYou earned 2 frequent renter points.");
        }

        [Fact]
        public void Statement_WhenHavingTwoNewReleaseMovies_ShouldGetTwoFrequentRenterPoints()
        {
            // Arrange
            var customer = new Customer("John Doe");
            customer.AddRental(new Rental(new Movie("Skyfall",Movie.PriceCode.NEW_RELEASE),1));
            customer.AddRental(new Rental(new Movie("Prometheus",Movie.PriceCode.NEW_RELEASE),1));
            // Act
            string statement = customer.Statement();
            // Assert
            statement.Should().Be("Rental Record for John Doe.\n\tSkyfall\t3$\n\tPrometheus\t3$\nAmount owed is 6$.\nYou earned 2 frequent renter points.");
        }

        [Fact]
        public void Statement_WhenHavingMoviesFromDifferentCategories_ShouldGetAppropriateStatement()
        {
            // Arrange
            var customer = new Customer("John Doe");
            customer.AddRental(new Rental(new Movie("Skyfall",Movie.PriceCode.NEW_RELEASE),1));
            customer.AddRental(new Rental(new Movie("The Lord Of The Rings",Movie.PriceCode.REGULAR),1));
            customer.AddRental(new Rental(new Movie("Brave",Movie.PriceCode.CHILDRENS),1));
            // Act
            string statement = customer.Statement();
            // Assert
            statement.Should().Be("Rental Record for John Doe.\n\tSkyfall\t3$\n\tThe Lord Of The Rings\t2$\n\tBrave\t1,5$\nAmount owed is 6,5$.\nYou earned 3 frequent renter points.");
        }

        [Fact(Skip = "not yet implemented")]
        public void HtmlStatement_WhenHavingMoviesFromDifferentCategories_ShouldGetAppropriateStatement()
        {
            // Arrange
            var customer = new Customer("John Doe");
            customer.AddRental(new Rental(new Movie("Skyfall", Movie.PriceCode.NEW_RELEASE), 1));
            customer.AddRental(new Rental(new Movie("The Lord Of The Rings",Movie.PriceCode.REGULAR),1));
            customer.AddRental(new Rental(new Movie("Brave",Movie.PriceCode.CHILDRENS),1));
            // Act
            //string statement = customer.HtmlStatement();
            string statement = string.Empty;
            // Assert
            statement.Should().Be("<H1>Rentals for <EM>John Doe</EM></H1><P>\nSkyfall: 3<BR>\nThe Lord Of The Rings: 2" +
                                  "<BR>\nBrave: 1,5<BR>\n<P>You owe <EM>6,5</EM><P>\nOn this rental you earned <EM>3</EM>" +
                                  " frequent renter points<P>");
        }

    }
}
