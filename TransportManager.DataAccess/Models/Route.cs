using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mita.DataAccess;

namespace TransportManager.DataAccess.Models
{
    public class Route : DomainObject
    {
        public string Number { get; set; }
        public decimal Spread { get; set; }
        public DateTime StartTimeA { get; set; }
        public DateTime StartTimeB { get; set; }
        public DateTime EndTimeA { get; set; }
        public DateTime EndTimeB { get; set; }
    }
}
