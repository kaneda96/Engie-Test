using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Engie_Test.ViewModels
{
    public class PowerPlantViewModels
    {
        [Key]
        public int PowerPlantId { get; set; }
        
        [Required(ErrorMessage = "Informe o UC da Usina")]
        [MaxLength(50,ErrorMessage = "Máximo {0} caracteres")]
        [DisplayName("UC da Usina")]        
        public string PowerPlantUC { get; set; }

        [Required(ErrorMessage = "Informe o Fornecedor")]        
        [DisplayName("Fornecedor")]
        public int ProviderId { get; set; }

        [Required]
        [DisplayName("Ativo")]
        [DefaultValue(true)]
        public bool Enabled { get; set; }

        
        [DisplayName("Criação")]        
        public DateTime created_at { get; set; }

        [DisplayName("Última Atualização")]        
        public DateTime updated_at { get; set; }


        public virtual ProviderViewModels Provider { get; set; }
    }
}
