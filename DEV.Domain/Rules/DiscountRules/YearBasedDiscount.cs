using DEV.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DEV.Domain.Rules.DiscountRules
{
    public class YearBasedDiscount : RuleHandler<Car>
    {
        private const int YEAR_THRESHOLD_FOR_DISCOUNT = 2000;

        // If a car is built before January 2000, discount it by 10% 
        public override void HandleRequest(List<Car> carList)
        {
            carList.ForEach(car => car.Price = car.Year < YEAR_THRESHOLD_FOR_DISCOUNT ? Math.Ceiling(car.Price * (decimal)0.90) : car.Price);

            if (_successor != null)
            {
                _successor.HandleRequest(carList);
            }
        }
    }
}
