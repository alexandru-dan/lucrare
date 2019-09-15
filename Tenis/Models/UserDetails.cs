using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tenis.Models
{
    public class UserDetails
    {
        public int Id { get; set; }
        public User UserId { get; set; }
        public int Level { get; set; }
        public string Hand { get; set; }
    }
}
