using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tenis.Models;
using Tenis.Services.Interface;
using Tenis.ViewModels;
using Tenis.ViewModels.Field;

namespace Tenis.Services
{
    public class FieldsService :IFieldsService
    {
        private TenisDbContext context;
        public FieldsService (TenisDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<FieldGetModel> GetAll()
        {
            return context.Fields.Select(field => new FieldGetModel
            {
                Name = field.Name,
                Address = field.Address
            });
        }

        public Fields DeleteField (int id)
        {
            Fields existing = context.Fields.FirstOrDefault(u => u.Id == id);
            if (existing == null)
            {
                return null;
            }
            context.Fields.Remove(existing);
            context.SaveChanges();

            return existing;
        }

        public Fields Create (FieldPostModel fieldCreateInfo)
        {
            Fields existing = context.Fields.FirstOrDefault(
                u => u.NameId == fieldCreateInfo.NameId && u.FieldNumber == fieldCreateInfo.FieldNumber);
            if (existing != null)
            {
                return null;
            }

            context.Fields.Add(new Fields
            {
                Name = fieldCreateInfo.Name,
                NameId = fieldCreateInfo.NameId,
                FieldNumber = fieldCreateInfo.FieldNumber,
                Address = fieldCreateInfo.Address
            });
            context.SaveChanges();
            return context.Fields.FirstOrDefault(u => u.NameId == fieldCreateInfo.NameId && u.FieldNumber == fieldCreateInfo.FieldNumber);
        }

        public IEnumerable<FieldGetModel> GetByName(string name)
        {
            Fields existing = context.Fields.FirstOrDefault(u => u.Name.Contains(name));
            if (existing == null)
            {
                return GetAll();
            }

            return context.Fields.Select(field => new FieldGetModel
            {
                Name = field.Name,
                Address = field.Address
            }).Where(u => u.Name.Contains(name));
        }

        public Fields Upsert (int id, Fields modifiedField)
        {
            var existing = context.Fields.AsNoTracking().FirstOrDefault(field => field.Id == id);
            if (existing == null)
            {
                return null;
            }

            modifiedField.Id = existing.Id;
            context.Fields.Update(modifiedField);
            context.SaveChanges();

            return modifiedField;
        }
    }
}
