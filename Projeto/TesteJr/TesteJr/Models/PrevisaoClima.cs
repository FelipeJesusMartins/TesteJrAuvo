using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TesteJr.Models
{
    public class PrevisaoClima
    {
        public int Id { get; set; }
        public DateTime DataPrevisao { get; set; }
        public string Clima { get; set; }
        public decimal? Minima { get; set; }
        public decimal? Maxima { get; set; }
        public PrevisaoClima(Testejr.DAL.PrevisaoClima previsao)
        {
            Minima = previsao.TemperaturaMinima;
            Maxima = previsao.TemperaturaMaxima;
            Clima = previsao.Clima;
            DataPrevisao = previsao.DataPrevisao;
        }
    }
}