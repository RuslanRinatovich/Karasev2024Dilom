using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAssortmentCheck.Models
{
   public partial class Service
    {
        public string GetPhoto
        {
            get
            {
                if (Photo is null)
                    return null;
                return System.IO.Directory.GetCurrentDirectory() + @"\Images\" + Photo.Trim();
            }
        }
    }
}
