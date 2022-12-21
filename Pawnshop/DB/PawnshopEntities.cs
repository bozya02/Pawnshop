using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pawnshop.DB
{
    public partial class PawnshopEntities
    {
        private static PawnshopEntities _context;

        public static PawnshopEntities GetContext()
        {
            if (_context == null)
                _context = new PawnshopEntities();

            return _context;
        }
    }
}
