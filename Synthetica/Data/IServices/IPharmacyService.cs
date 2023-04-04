using System;
using Synthetica.Models;
using Synthetica.Data.Base;
using Synthetica.Data.ViewModels;

namespace Synthetica.Data.IServices
{
    public interface IPharmacyService : IEntityBaseRepository<Pharmacy>
    {
        Task AddNewPharmacyAsync(PharmacyVM data);
        Task UpdatePharmacyAsync(PharmacyVM data);
    }
}

