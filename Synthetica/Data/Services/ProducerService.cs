using System;
using Synthetica.Data.Base;
using Synthetica.Models;
using Synthetica.Data.IServices;
using Synthetica.Data.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Synthetica.Data.Services
{
    public class ProducerService : EntityBaseRepository<Producer>, IProducerService
    {
        private readonly DatabaseContext _context;

        public ProducerService(DatabaseContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewProducerAsync(ProducerVM data)
        {
            var producer = new Producer()
            {
                Image = data.Image,
                Name = data.Name,
                Description = data.Description,
            };

            await _context.Producers.AddAsync(producer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProducerAsync(ProducerVM data)
        {
            var dbProducer = await _context.Producers.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (dbProducer != null)
            {
                dbProducer.Image = data.Image;
                dbProducer.Name = data.Name;
                dbProducer.Description = data.Description;

                await _context.SaveChangesAsync();
            }
        }
    }
}

