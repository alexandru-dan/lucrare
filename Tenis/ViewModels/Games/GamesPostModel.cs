using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tenis.Models;

namespace Tenis.ViewModels.Games
{
    public class GamesPostModel
    {
        public Fields FieldNameAndFieldNumber { get; set; }
        public DateTime DateTime { get; set; }
    }
}
