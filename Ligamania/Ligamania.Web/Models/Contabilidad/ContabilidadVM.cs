using Ligamania.Generic.Lib.Enums;

using System.ComponentModel.DataAnnotations;

namespace Ligamania.Web.Models.Contabilidad
{
    public class ContabilidadVM : BaseVM
    {
        public string Temporada { get; set; }
        [Display(Name ="Nº de equipos")]
        public int Equipos { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public double Gastos 
        { 
            get 
            {
                var gastos = Conceptos.Sum(c => c.Gasto && c.PorEquipo.ToUpper().Equals("NO") ? c.Valor : 0);
                var porequi = Conceptos.Where(c => c.PorEquipo.ToUpper().Equals("SI")).Sum(c => c.Gasto ? c.Valor * Equipos : 0);
                return gastos + porequi; 
            }
        }
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public double Ingresos 
        {
            get 
            {
                var ingresos = Conceptos.Sum(c => c.Gasto && c.PorEquipo.ToUpper().Equals("NO") ? 0: c.Valor);
                var porequi = Conceptos.Where(c => c.PorEquipo.ToUpper().Equals("SI")).Sum(c => c.Gasto ? 0: c.Valor * Equipos);
                return ingresos + porequi;
            }
        }
        [DisplayFormat(DataFormatString = "##.##", ApplyFormatInEditMode = true)]
        public double Premios { get { return Ingresos - Gastos; } }
        public List<ConceptoContabilidad> Conceptos { get; set; }
        public List<PremioContabilidadVM> RepartoPremios { get; set; }
    }
    public class ConceptoContabilidad
    { 
        public int Id { get; set; }
        public string Concepto { get; set; }

        [Display(Name ="Gasto")]
        public double ConcGasto { get; set; }

        [Display(Name = "Ingreso")]
        public double ConcIngreso { get; set; }

        [Display(Name="Concepto por equipo")]
        public string PorEquipo { get; set; }

        public double Valor { get; set; }
       
        public bool Gasto { get; set; }

        public string Temporada { get; set; }
    }
    public class PremioContabilidadVM
    {
        public int Id { get; set; }
        public string Competicion { get; set; }
        public string Categoria { get; set; }
        public string Equipo { get; set; }
        public double Premio { get; set; }
        public double Porcentaje { get; set; }
        public PuestoCompeticion Puesto { get; set; }
        public string PuestoStr { get; set; } 
    }
}
