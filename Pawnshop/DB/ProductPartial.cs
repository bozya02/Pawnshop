using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pawnshop.DB
{
    public partial class Product
    {
        public override string ToString()
        {
            return Name;
        }

        public double Commission
        {
            get => (double)Price * 0.2;
            set { }
        }
    }
}
