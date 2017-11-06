using System.Collections.Generic;

namespace VideoStoreStart
{
    public class Customer
    {
        private readonly string _name;
        private readonly List<Rental> _rentals = new List<Rental>();

        public Customer(string name)
        {
            _name = name;
        }

        public void AddRental(Rental arg)
        {
            _rentals.Add(arg);
        }

        public string GetName()
        {
            return _name;
        }

        public string Statement()
        {
            double totalAmount = 0;
            var frequentRenterPoints = 0;

            var result = "Rental Record for " + GetName() + ".\n";
            foreach (var rental in _rentals)
            {
                double thisAmount = 0;

                //determine amounts for each line
                var priceCode = rental.GetMovie().GetPriceCode();
                switch (priceCode)
                {
                    case Movie.PriceCode.REGULAR:
                        thisAmount += 2;
                        if (rental.GetDaysRented() > 2)
                            thisAmount += (rental.GetDaysRented() - 2) * 1.5;
                        break;
                    case Movie.PriceCode.NEW_RELEASE:
                        thisAmount += rental.GetDaysRented() * 3;
                        break;
                    case Movie.PriceCode.CHILDRENS:
                        thisAmount += 1.5;
                        if (rental.GetDaysRented() > 3)
                            thisAmount += (rental.GetDaysRented() - 3) * 1.5;
                        break;
                }
                // add frequent renter points
                frequentRenterPoints++;
                // add bonus for a two day new release rental
                if ((priceCode == Movie.PriceCode.NEW_RELEASE) && rental.GetDaysRented() > 1)
                {
                    frequentRenterPoints++;
                }
                //show figures for this rental
                result += "\t" + rental.GetMovie().GetTitle() + "\t" + thisAmount + "$\n";
                totalAmount += thisAmount;
            }
            //add footer lines
            result += "Amount owed is " + totalAmount + "$.\n";
            result += "You earned " + frequentRenterPoints + " frequent renter points.";
            return result;
        }
    }
}