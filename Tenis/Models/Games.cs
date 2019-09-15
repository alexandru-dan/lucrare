using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tenis.Models
{
    public class Games
    {
        public int Id { get; set; }
        public User NameAndSurnameFirstPlayer { get; set; }
        public User NameAndSurnameSecondPlayer { get; set; }
        public Fields FieldNameAndFieldNumber { get; set; }
        public string Score { get; set; }
        public string Status { get; set; }
        public DateTime DateTime { get; set; }
    }
}
