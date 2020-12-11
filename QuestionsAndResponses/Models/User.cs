using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionsAndResponses.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [EmailAddress]
        [MaxLength(50)]
        [Display(Name = "E-Mail")]
        public string EMail { get; set; }
        [Required]
        [MaxLength(200)]
        [Display(Name = "Nome")]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name = "Senha")]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Criado Em")]
        public DateTime CreatedIn { get; set; }
    }
}
