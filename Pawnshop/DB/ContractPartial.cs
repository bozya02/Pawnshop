using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pawnshop.DB
{
    public partial class Contract
    {
        public override string ToString()
        {
            return $"№{Id} от {Date.ToString("dd.MM.yyyy")}";
        }

        public DateTime ExpireDate => Date.AddDays(30);
    }
}
