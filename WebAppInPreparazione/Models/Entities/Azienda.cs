using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppInPreparazione.Models.Entities
{
    public class Azienda
    {
        public int Id { get; set; }

        [Display(Name = "Denominazione")]
        [Required(ErrorMessage = " Il campo 'denominazione' è obbligatorio")]
        public string Denominazione { get; set; }


    }
}
