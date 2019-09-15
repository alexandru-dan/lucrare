using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tenis.Models;

namespace Tenis.ViewModels.Field
{
    public class FieldPostModel
    {
        public string Name { get; set; }
        public string NameId { get; set; }
        public string FieldNumber { get; set; }
        public string Address { get; set; }

        public static Fields ToFields(FieldPostModel fieldPostModel)
        {
            return new Fields()
            {
                Name = fieldPostModel.Name,
                NameId = fieldPostModel.NameId,
                FieldNumber = fieldPostModel.FieldNumber,
                Address = fieldPostModel.Address
            };
        }
    }
}
