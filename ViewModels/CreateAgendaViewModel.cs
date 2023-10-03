using System.ComponentModel.DataAnnotations;

namespace Agenda.ViewModels
{
    //Contém o que será mostrado
    public class CreateAgendaViewModel
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório!")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "O campo Telefone é obrigatório!")]
        [StringLength(11, MinimumLength = 10, ErrorMessage = "O campo precisa ter de 10 a 11 caracteres")]
        public string? Telefone { get; set; }

        [Required(ErrorMessage = "O campo DataNascimento é obrigatório!")]
        public DateTime DataNascimento { get; set; }
    }
}