using DEV.Domain.Entities;

namespace DEV.Tests.Builders.ModelBuilders
{
    internal class CarModelBuilder
    {
        private readonly Car _Car;

        internal CarModelBuilder()
        {
            _Car = new Car
            {

                Id = 0,

                Make = string.Empty,

                Model = string.Empty,

                Year = 0,

                CountryManufactured = string.Empty,

                Colour = string.Empty,

                Price = 0M,

            };
        }


        internal CarModelBuilder WithId(int Id)
        {
            _Car.Id = Id;
            return this;
        }

        internal CarModelBuilder WithMake(string Make)
        {
            _Car.Make = Make;
            return this;
        }

        internal CarModelBuilder WithModel(string Model)
        {
            _Car.Model = Model;
            return this;
        }

        internal CarModelBuilder WithYear(int Year)
        {
            _Car.Year = Year;
            return this;
        }

        internal CarModelBuilder WithCountryManufactured(string CountryManufactured)
        {
            _Car.CountryManufactured = CountryManufactured;
            return this;
        }

        internal CarModelBuilder WithColour(string Colour)
        {
            _Car.Colour = Colour;
            return this;
        }

        internal CarModelBuilder WithPrice(decimal Price)
        {
            _Car.Price = Price;
            return this;
        }


        internal Car Build()
        {
            return _Car;
        }
    }
}
