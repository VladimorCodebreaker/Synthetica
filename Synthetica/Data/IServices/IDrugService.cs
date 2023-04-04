using System;
using Synthetica.Data.Base;
using Synthetica.Models;
using Synthetica.Data.ViewModels;

namespace Synthetica.Data.IServices
{
	public interface IDrugService : IEntityBaseRepository<Drug>
	{
        Task<Drug> GetDrugByIdAsync(int id);
        Task<DrugDropdown> GetNewDrugsDropdownsValues();
        Task AddNewDrugAsync(DrugVM data);
        Task UpdateDrugAsync(DrugVM data);
    }
}

