using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagosXml.Dominio
{
    internal class Persona
    {
        string Nombre;
        string Apellidos;
        string Dni;
        string Iban;
        float Cantidad;

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
        public float Cantidad1 { get => Cantidad; set => Cantidad = value; }
    }
}
