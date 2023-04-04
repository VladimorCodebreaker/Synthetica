using System;
using Synthetica.Models;
using Synthetica.Data;
using Synthetica.Data.Base;
using Synthetica.Data.IServices;
using Microsoft.EntityFrameworkCore;
using Synthetica.Data.ViewModels;

namespace Synthetica.Data.Services
{
    public class PharmacyService : EntityBaseRepository<Pharmacy>, IPharmacyService
    {
        private readonly DatabaseContext _context;

        public PharmacyService(DatabaseContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewPharmacyAsync(PharmacyVM data)
        {
            var pharmacy = new Pharmacy()
            {
                Logo = data.Logo,
                Name = data.Name,
                Description = data.Description,
            };

            await _context.Pharmacies.AddAsync(pharmacy);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePharmacyAsync(PharmacyVM data)
        {
            var dbPharmacy = await _context.Pharmacies.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (dbPharmacy != null)
            {
                dbPharmacy.Logo = data.Logo;
                dbPharmacy.Name = data.Name;
                dbPharmacy.Description = data.Description;

                await _context.SaveChangesAsync();
            }
        }
    }
}

