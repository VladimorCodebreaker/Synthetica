using System;
using Synthetica.Data.Base;
using Synthetica.Models;
using Synthetica.Data.ViewModels;
using Microsoft.EntityFrameworkCore;
using Synthetica.Data.IServices;

namespace Synthetica.Data.Services
{
    public class DrugService : EntityBaseRepository<Drug>, IDrugService
    {
        private readonly DatabaseContext _context;

        public DrugService(DatabaseContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewDrugAsync(DrugVM data)
        {
            var drug = new Drug()
            {
                Image = data.Image,
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                DrugCategory = data.DrugCategory,
                PharmacyId = data.PharmacyId,
                ProducerId = data.ProducerId
            };
            await _context.Drugs.AddAsync(drug);
            await _context.SaveChangesAsync();

            //Add Drug Substances
            foreach (var substanceId in data.SubstanceIds)
            {
                var DrugSubstance = new Substance_Drug()
                {
                    DrugId = drug.Id,
                    SubstanceId = substanceId
                };
                await _context.Substance_Drugs.AddAsync(DrugSubstance);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<Drug> GetDrugByIdAsync(int id)
        {
            var drug = await _context.Drugs
                .Include(c => c.Pharmacy)
                .Include(p => p.Producer)
                .Include(sd => sd.Substance_Drugs).ThenInclude(a => a.Substance)
                .FirstOrDefaultAsync(n => n.Id == id);

            return drug;
        }

        public async Task<DrugDropdown> GetNewDrugsDropdownsValues()
        {
            var response = new DrugDropdown()
            {
                Substances = await _context.Substances.OrderBy(n => n.Name).ToListAsync(),
                Pharmacies = await _context.Pharmacies.OrderBy(n => n.Name).ToListAsync(),
                Producers = await _context.Producers.OrderBy(n => n.Name).ToListAsync()
            };

            return response;
        }

        public async Task UpdateDrugAsync(DrugVM data)
        {
            var dbDrug = await _context.Drugs.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (dbDrug != null)
            {
                dbDrug.Name = data.Name;
                dbDrug.Description = data.Description;
                dbDrug.Price = data.Price;
                dbDrug.Image = data.Image;
                dbDrug.DrugCategory = data.DrugCategory;
                dbDrug.PharmacyId = data.PharmacyId;
                dbDrug.ProducerId = data.ProducerId;

                await _context.SaveChangesAsync();
            }

            //Remove existing Substances
            var _dbDrug = _context.Substance_Drugs.Where(n => n.DrugId == data.Id).ToList();
            _context.Substance_Drugs.RemoveRange(_dbDrug);

            await _context.SaveChangesAsync();

            //Add Drug Substances
            foreach (var substanceId in data.SubstanceIds)
            {
                var newSubstanceDrug = new Substance_Drug()
                {
                    DrugId = data.Id,
                    SubstanceId = substanceId
                };
                await _context.Substance_Drugs.AddAsync(newSubstanceDrug);
            }
            await _context.SaveChangesAsync();
        }
    }
}

