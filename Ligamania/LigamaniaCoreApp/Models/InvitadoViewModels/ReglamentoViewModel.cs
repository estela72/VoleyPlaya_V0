using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Models.InvitadoViewModels
{
    public class ReglamentoViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        public string Name { get; set; }
        [Display(Name = "Descripción")]
        public string Description { get; set; }

        [Display(Name = "Fichero")]
        public byte[] Content { get; set; }

        [Display(Name="Tipo de fichero")]
        public string ContentType { get; set; }

    }
}
