using System;
using Testejr.DAL;

namespace TesteJr.Models
{
    /// <summary>
    /// Temperatura da cidade especificada 
    /// </summary>
    public class TemperaturaCidade
    {
        /// <summary>
        /// Nome da <see cref="Cidade"/> dessa temperatura 
        /// </summary>
        public string Cidade { get; set; }

        /// <summary>
        /// Previsão de Temperatura Minima da Cidade
        /// </summary>
        public decimal? Minima { get; set; }

        /// <summary>
        /// Previsão Temperatura Maxima da Cidade <see cref="Cidade"/>
        /// </summary>
        public decimal? Maxima { get; set; }

        public TemperaturaCidade(Cidade cidade, Testejr.DAL.PrevisaoClima previsao)
        {
            if (cidade.Id != previsao.CidadeId)
                throw new ArgumentException("A temperatura deve ser da mesma cidade!");

            Minima = previsao.TemperaturaMinima;
            Maxima = previsao.TemperaturaMaxima;
            Cidade = cidade.Nome;
        }
    }
}