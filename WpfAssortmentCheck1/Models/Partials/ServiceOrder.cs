using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAssortmentCheck.Models
{
    public partial class ServiceOrder
    {
        public double TotalPrice
        {
            get
            {
                return Service.Price * Count;
            }
        }
    }
}
