using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using TesteJr.Controllers.Base;
using Testejr.DAL;
using TesteJr.Models;

namespace TesteJr.Controllers
{
    public class HomeController : BaseController
    {
        private const int MaximoTemperaturas = 2;
        public const int MaximoDiasListagem = 7;
        public async Task<ActionResult> Index()
        {
            var nowEnd = DateTime.UtcNow.AddDays(1);
            var nowStart = DateTime.UtcNow.AddDays(-1);

            var selectTemperaturas = (from temp in db.PrevisaoClimas
                                      where temp.DataPrevisao < nowEnd &&
                                            temp.DataPrevisao > nowStart
                                      orderby temp.TemperaturaMaxima descending
                                      select temp)
                .DistinctBy(temp => temp.CidadeId);

            var maisQuentes = selectTemperaturas
                .Take(MaximoTemperaturas)
                .ToArray();

            var maisFrias = selectTemperaturas
                .OrderBy(temp => temp.TemperaturaMinima)
                .Take(MaximoTemperaturas)
                .ToArray();

            var cidades = await (from cid in db.Cidades
                                 select cid).ToArrayAsync();


            var model = new HomeModel(Array.Empty<TemperaturaCidade>(),
                Array.Empty<TemperaturaCidade>(),
                cidades)
            {

                MaisQuentes = (from temp in maisQuentes
                               select new TemperaturaCidade(
                                   cidades.FirstOrDefault(fs => fs.Id == temp.CidadeId),
                                   temp)).ToArray(),

                MaisFrias = (from temp in maisFrias
                             select new TemperaturaCidade(
                             cidades.FirstOrDefault(fs => fs.Id == temp.CidadeId),
                             temp)).ToArray()
            };

            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> ObterPrevisoes(int idCidade)
        {
            Cidade cidade = await (from cid in db.Cidades
                                   where cid.Id == idCidade
                                   select cid).FirstOrDefaultAsync();

            var nowEnd = DateTime.UtcNow.AddDays(MaximoDiasListagem);

            var temperaturas = (await (from temp in db.PrevisaoClimas
                                       where
                                           temp.CidadeId == cidade.Id &&
                                           temp.DataPrevisao < nowEnd &&
                                           temp.DataPrevisao > DateTime.UtcNow
                                       select temp).ToArrayAsync())
                .ToArray()
                .Select(sl => new Models.PrevisaoClima(sl))
                .ToArray();

            ViewBag.Cidade = cidade.Nome;
            
            return View("UltimasPrevisoes", temperaturas);
        }

        public ActionResult About()
        {
            return View();
        }
    }
}