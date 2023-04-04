using System;
using Synthetica.Models;
using Synthetica.Data.Base;
using Synthetica.Data.ViewModels;

namespace Synthetica.Data.IServices
{
    public interface ISubstanceService : IEntityBaseRepository<Substance>
    {
        Task AddNewSubstanceAsync(SubstanceVM data);
        Task UpdateSubstanceAsync(SubstanceVM data);
    }
}

