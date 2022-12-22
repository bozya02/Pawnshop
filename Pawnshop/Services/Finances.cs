using Pawnshop.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Pawnshop.Services
{
    public class Finances
    {
        public static Statistic GetStatistic(List<Product> products, DateTime startDate, DateTime endDate)
        {
            Statistic statistic = new Statistic();

            foreach (var product in products)
            {
                if (startDate.Date <= product.Contract.Date && product.Contract.Date <= endDate.Date)
                    statistic.Spending += (double)product.Price;

                if (product.IsSold && (startDate.Date <= ((DateTime)product.SoldDate).Date & ((DateTime)product.SoldDate).Date <= endDate.Date))
                {
                    statistic.Income += (double)product.Price;
                }
                else if (product.IsRedeemed && (startDate.Date <= ((DateTime)product.RedeemedDate).Date & ((DateTime)product.RedeemedDate).Date <= endDate.Date))
                {
                    statistic.Income += ((double)product.Price + product.Commission);
                }
            }

            return statistic;
        }
    }
}
