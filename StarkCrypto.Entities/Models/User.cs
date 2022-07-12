using StarkCrypto.Entities.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StarkCrypto.Entities.Models
{
    public class User
    {

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string CellPhone { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Cpf { get; set; }

        public ePerfil Perfil { get; set; }
        public bool isAdmin { get; set; }
        public bool Status { get; set; }
    }
}
