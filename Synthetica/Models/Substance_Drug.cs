using System;

namespace Synthetica.Models
{
    public class Substance_Drug
    {
        public int SubstanceId { get; set; }
        public Substance Substance { get; set; }

        public int DrugId { get; set; }
        public Drug Drug { get; set; }
    }
}

