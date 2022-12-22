using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pawnshop.Services
{
    public class Statistic
    {
        public double Income { get; set; }
        public double Spending { get; set; }
        public double Profit => Income - Spending;

        public Statistic()
        {
            Income = 0;
            Spending = 0;
        }
    }
}
