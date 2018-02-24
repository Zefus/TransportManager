using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mita.DataAccess;

namespace TransportManager.DataAccess.Models
{
    public class Driver : FullNamedDomainObject
    {
        public string Phone { get; set; }
        public string Shift { get; set; }
    }
}
