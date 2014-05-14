using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NativaGaragem.Models
{
    [MetadataType(typeof(GaragemMetadado))]
    public partial class Garagem
    {
    }

    public class GaragemMetadado
    {
        [Required(ErrorMessage="Obrigatório informar o nome")]
        [StringLength(80, ErrorMessage="O nome deve conter no máximo 80 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a quantidade de vagas")]
        public int QuantidadeVagas { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a quantidade de vagas livres")]
        public string QuantidadeVagasLivres { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o endereço")]
        [StringLength(100, ErrorMessage = "O nome deve conter no máximo 100 caracteres")]
        public string Endereco { get; set; }
    }
}