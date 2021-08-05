using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Engie_Test.Entitites
{
    public class PowerPlant
    {        
        public int PowerPlantId { get; set; }
        public string PowerPlantUC { get; set; }
        public bool Enabled { get; set; }       
        public DateTime CreatedAt { get; set; }       
        public DateTime UpdatedAt { get; set; }
        public int ProviderId { get; set; }
        public virtual Provider Provider { get; set; }
        

    }
}
