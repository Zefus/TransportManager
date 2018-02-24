using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mita.DataAccess;
using TransportManager.DataAccess.Enums;

namespace TransportManager.DataAccess.Models
{
    public class Card : DomainObject
    {
        public decimal Balance { get; set; }
        public string Number { get; set; }
        public CardStatus Status { get; set; }
        public CardType Type { get; set; }
        public string ActionType { get; set; }
    }
}
