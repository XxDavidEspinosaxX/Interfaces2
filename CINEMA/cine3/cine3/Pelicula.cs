using System;
using System.Collections.Generic;

namespace cine3
{
    public class Pelicula
    {
        public string Titol { get; set; }
        public string Sala { get; set; }
        public List<string> Idioma { get; set; }
        public List<string> Genero { get; set; }
        public DateTime DataInici { get; set; }
        public DateTime DataFinal { get; set; }
        public List<string> HourList { get; set; }
        public List<string> MinuteList { get; set; }
        public string Duracion { get; set; }

        // Constructor
        public Pelicula(string titol, string sala, List<string> idioma, List<string> genero, DateTime dataInici, DateTime dataFinal, List<string> hourList, List<string> minuteList, string duracion)
        {
            this.Titol = titol;
            this.Sala = sala;
            this.Idioma = idioma;
            this.Genero = genero;
            this.DataInici = dataInici;
            this.DataFinal = dataFinal;
            this.HourList = hourList;
            this.MinuteList = minuteList;
            this.Duracion = duracion;
        }
    }
}
