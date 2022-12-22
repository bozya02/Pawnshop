using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pawnshop.DB
{
    public partial class Client
    {
        public override string ToString()
        {
            return $"{LastName} {FirstName[0]}." + (string.IsNullOrEmpty(Patronymic) ? "" : $"{Patronymic[0]}.");
        }
    }
}
