using System;
using Synthetica.Models;
using System.Numerics;

namespace Synthetica.Data.ViewModels
{
	public class DrugDropdown
	{
        public DrugDropdown()
        {
            Producers = new List<Producer>();
            Pharmacies = new List<Pharmacy>();
            Substances = new List<Substance>();
        }

        public List<Producer> Producers { get; set; }
        public List<Pharmacy> Pharmacies { get; set; }
        public List<Substance> Substances { get; set; }
    }
}

