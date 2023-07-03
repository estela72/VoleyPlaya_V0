using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagosXml.Dominio
{
    public class Persona
    {
        string Nombre = string.Empty;
        string Apellidos = string.Empty;
        string Dni = string.Empty;
        string Iban = string.Empty;
        double Cantidad = 0;

        public Persona() { }

        public Persona(string nombre, string apellidos, string dni, string iban, float cantidad)
            :this()
        {
            Nombre1 = nombre;
            Apellidos1 = apellidos;
            Dni1 = dni;
            Iban1 = iban;
            Cantidad1 = cantidad;
        }

        public string Nombre1 { get => Nombre; set => Nombre = value; }
        public string Apellidos1 { get => Apellidos; set => Apellidos = value; }
        public string Dni1 { get => Dni; set => Dni = value; }
        public string Iban1 { get => Iban; set => Iban = value; }
        public double Cantidad1 { get => Cantidad; set => Cantidad = value; }
    }
}
