using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppInPreparazione.Models.Entities;

namespace WebAppInPreparazione.Models.Views
{
    public class DipendenteViewModel : Dipendente
    {
        public List <Azienda> ListaAziende { get; set; }

        public DipendenteViewModel() { }

        public DipendenteViewModel(Dipendente dipendente, List<Azienda> listaAziende)
        {
            Id = dipendente.Id;
            Nome = dipendente.Nome;
            IdAzienda = dipendente.IdAzienda;
            ListaAziende = listaAziende;

        }
    }
}
