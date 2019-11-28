using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using GimnasioFenix.Models;

namespace GimnasioFenix.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DataListController : Controller
    {
        private DBContext db = new DBContext();

        // GET: DataList
        public ActionResult Index()
        {
            var dataList = new DataList();
            dataList.Dias = db.Dia.ToList();
            dataList.Horarios = db.Horario.ToList();
            dataList.GrillaActividades = new Actividad[dataList.Horarios.Count, dataList.Dias.Count];
            var actividades = db.Actividad.ToList();

            int h = 0;
            foreach (var horario in dataList.Horarios)
            {

                int d = 0;
                foreach (var dia in dataList.Dias)
                {
                    var actividad = actividades.Where(c => c.IdDia == horario.Id && c.IdHorario == dia.Id).FirstOrDefault();


                    dataList.GrillaActividades[h, d] = actividad;
                    d++;
                }
                h++;
            }
            return View(dataList);
        }
    }
}