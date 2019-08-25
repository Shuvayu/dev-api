using DEV.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DEV.Domain.Rules.DiscountRules
{
    public class TotalCountDiscount : RuleHandler<Car>
    {
        private const int TOTAL_NUMBER_THRESHOLD = 2;

        //If number of cars is more than 2, apply 3% discount
        public override void HandleRequest(List<Car> carList)
        {
            if (carList.Count > TOTAL_NUMBER_THRESHOLD)
            {
                carList.ForEach(car => car.Price = Math.Ceiling(car.Price * (decimal)0.97));
            }

            if (_successor != null)
            {
                _successor.HandleRequest(carList);
            }
        }
    }
}
