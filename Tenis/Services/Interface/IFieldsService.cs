using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tenis.Models;
using Tenis.ViewModels;
using Tenis.ViewModels.Field;

namespace Tenis.Services.Interface
{
    public interface IFieldsService
    {
        IEnumerable<FieldGetModel> GetAll();
        Fields DeleteField(int id);
        Fields Create(FieldPostModel fieldCreateInfo);
        IEnumerable<FieldGetModel> GetByName(string name);
        Fields Upsert(int id, Fields modifiedField);
    }
}
