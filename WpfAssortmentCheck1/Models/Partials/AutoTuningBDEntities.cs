using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAssortmentCheck.Models
{
    public partial class AutoTuningBDEntities : DbContext
    {
       
        private static AutoTuningBDEntities _context;


        public static AutoTuningBDEntities GetContext()
        {
            if (_context == null)
            {
                _context = new AutoTuningBDEntities();
            }
            return _context;
        }
    }
}
