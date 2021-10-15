using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Riod.WebUI.Models.Entities
{
    public class Contact
    {
        public int Id { get; set; }
        [Required (ErrorMessage ="Adinizi daxil edin")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Mailinizi daxil edin")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Mesajinizi daxil edin")]
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string Answer { get; set; }
        public DateTime? AnswerDate { get; set; }
        public int? AnswerId { get; set; }
    }
}
