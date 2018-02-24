using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mita.DataAccess;

namespace TransportManager.DataAccess.Models
{
    public class Transact : DomainObject
    {
        public DateTime Date { get; set; }
        public string Number { get; set; }

        public int Amount { get; set; }
    }
}
