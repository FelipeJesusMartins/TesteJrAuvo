using System.Collections.Generic;
using Testejr.DAL;

namespace TesteJr.Models
{
    public class HomeModel
    {
        public IEnumerable<TemperaturaCidade> MaisFrias { get; set; }
        public IEnumerable<TemperaturaCidade> MaisQuentes { get; set; }
        public IEnumerable<Cidade> Cidades { get; set; }
        public HomeModel(IEnumerable<TemperaturaCidade> maisFrias, IEnumerable<TemperaturaCidade> maisQuentes, IEnumerable<Cidade> cidades)
        {
            MaisFrias = maisFrias;
            MaisQuentes = maisQuentes;
            Cidades = cidades;
        }
    }
}