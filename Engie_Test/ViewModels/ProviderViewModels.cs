using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Engie_Test.ViewModels
{
    public class ProviderViewModels
    {
        [Key]
        public int ProviderId { get; set; }

        [Required(ErrorMessage = "Nome do fornecedor é obrigatório")]
        [MaxLength(100,ErrorMessage = "Máximo {0} caracteres")]
        [DisplayName("Fornecedor")]
        public string Name { get; set; }
    }
}
