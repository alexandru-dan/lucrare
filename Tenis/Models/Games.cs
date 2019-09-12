using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tenis.Models
{
    public class Games
    {
        public int Id { get; set; }
        public int User1Id { get; set; }
        public int User2Id { get; set; }
        public int FieldId { get; set; }
        public string Score { get; set; }
        public string Status { get; set; }
        public DateTime DateTime { get; set; }
    }
}
