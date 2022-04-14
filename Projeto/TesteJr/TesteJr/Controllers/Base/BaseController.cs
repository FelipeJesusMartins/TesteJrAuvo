using System.Web;
using System.Web.Mvc;
using Testejr.DAL;

namespace TesteJr.Controllers.Base 
{
    public class BaseController : Controller
    {
        private protected readonly ClimaTempoSimplesEntities db;

        public BaseController()
        {
            db = new ClimaTempoSimplesEntities();
        }
    }
}