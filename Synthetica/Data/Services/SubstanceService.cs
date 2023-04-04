using System;
using Synthetica.Models;
using Synthetica.Data;
using Synthetica.Data.Base;
using Synthetica.Data.IServices;
using Synthetica.Data.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Synthetica.Data.Services
{
    public class SubstanceService : EntityBaseRepository<Substance>, ISubstanceService
    {
        private readonly DatabaseContext _context;

        public SubstanceService(DatabaseContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewSubstanceAsync(SubstanceVM data)
        {
            var substance = new Substance()
            {
                Image = data.Image,
                Name = data.Name,
                Description = data.Description,
            };

            await _context.Substances.AddAsync(substance);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSubstanceAsync(SubstanceVM data)
        {
            var dbSubstance = await _context.Substances.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (dbSubstance != null)
            {
                dbSubstance.Image = data.Image;
                dbSubstance.Name = data.Name;
                dbSubstance.Description = data.Description;

                await _context.SaveChangesAsync();
            }
        }
    }
}

