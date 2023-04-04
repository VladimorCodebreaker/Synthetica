using System;
using Synthetica.Data.Base;
using Synthetica.Data.ViewModels;
using Synthetica.Models;

namespace Synthetica.Data.IServices
{
	public interface IProducerService : IEntityBaseRepository<Producer>
	{
        Task AddNewProducerAsync(ProducerVM data);
        Task UpdateProducerAsync(ProducerVM data);
    }
}

