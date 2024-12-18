using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidades
{
    public class AnelEntidade : BaseEntity
    {
        //Detalhes e caracteristicas do banco
        [MaxLength(150)]
        public required string Nome { get; set; }

        public string Poder { get; set; }

        public string Portador { get; set; }

        public string ForjadoPor { get; set; }

        public string Imagem { get; set; }

        public TipoAnel TipoAnel { get; set; }
    }
}
