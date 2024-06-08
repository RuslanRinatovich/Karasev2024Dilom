using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAssortmentCheck.Models
{
   public partial class User
    {
        public string GetInfo
        {
            get
            {
                return $" {LastName}  {FirstName}\nтелефон: {Phone}\nemail:{Email}";
            }
        }

        public string GetFio
        {
            get
            {
                return $" {LastName}  {FirstName} {MiddleName}";
            }
        }
    }
}
