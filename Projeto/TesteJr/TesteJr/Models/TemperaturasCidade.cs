using System;
using System.Collections.Generic;
using Testejr.DAL;

namespace TesteJr.Models
{
    /// <summary>
    /// Temperatura da cidade especificada 
    /// </summary>
    public class TemperaturasCidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int EstadoId { get; set; }
        public IEnumerable<PrevisaoClima> UltimasPrevisoes { get; set; }

        public TemperaturasCidade(Cidade cidade, IEnumerable<PrevisaoClima> ultimasTemperaturas) 
            : this(cidade.Id, cidade.Nome, cidade.EstadoId, ultimasTemperaturas)
        {

        }

        public TemperaturasCidade(int id, string nome, int estadoId, IEnumerable<PrevisaoClima> ultimasTemperaturas)
        {
            Id = id;
            Nome = nome;
            EstadoId = estadoId;
            UltimasPrevisoes = ultimasTemperaturas;
        }
    }
}