using DEV.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DEV.Domain.Rules.DiscountRules
{
    public class TotalCostDiscount : RuleHandler<Car>
    {
        // If total cost exceeds $100,000 apply 5% discount
        private const int TOTAL_COST_DISCOUNT_THRESHOLD = 100000;

        public override void HandleRequest(List<Car> carList)
        {
            var totalSum = carList.Sum(car => car.Price);
            if (totalSum > TOTAL_COST_DISCOUNT_THRESHOLD)
            {
                carList.ForEach(car => car.Price = Math.Ceiling(car.Price * (decimal)0.95));
            }

            if (_successor != null)
            {
                _successor.HandleRequest(carList);
            }
        }
    }
}
