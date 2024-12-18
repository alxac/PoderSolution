using System.ComponentModel.DataAnnotations;

namespace Dominio.DTO
{
    //Caracteristicas das informações
    public class AnelDTOCreate
    {
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [MaxLength(150, ErrorMessage = "O nome pode ter no máximo 150 caracteres.")]
        public string Nome { get; set; }
        public string Poder { get; set; }
        public string Portador { get; set; }
        public string ForjadoPor { get; set; }
        public string Imagem { get; set; }
        public TipoAnel TipoAnel { get; set; }
    }
}
