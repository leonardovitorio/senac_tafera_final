using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionsAndResponses.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(500)]
        [Display(Name = "Descrição")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Usuário")]
        public int UserId { get; set; }
        [Display(Name = "Usuário")]
        public User User { get; set; }
        [Display(Name = "Respostas")]
        public List<Response> Responses { get; set; }
        [Required]
        [Display(Name = "Criado Em")]
        public DateTime CreatedIn { get; set; }
    }
}
