using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppInPreparazione.Models.Entities
{
    public class Dipendente
    {
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = " Il campo 'nome' è obbligatorio")]
        public String Nome { get; set; }

        [Display(Name = "Cognome")]
        [Required(ErrorMessage = " Il campo 'cognome' è obbligatorio")]
        public String Cognome { get; set; }

        [Display(Name = "Azienda")]
        [Required]
        public int IdAzienda { get; set; }

        public Azienda Azienda { get; set; }


        [Display(Name = "Foto")]
        public string FotoDipendente { get; set; }

    }
}
