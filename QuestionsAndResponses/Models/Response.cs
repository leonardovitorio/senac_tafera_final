using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionsAndResponses.Models
{
    public class Response
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(500)]
        [Display(Name = "Descrição")]
        public string Description { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        [Display(Name = "Questão")]
        public int QuestionId { get; set; }
        [Required]
        [Display(Name = "Criado Em")]
        public DateTime CreatedIn { get; set; }
    }
}
