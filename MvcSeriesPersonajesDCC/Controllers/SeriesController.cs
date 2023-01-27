using Microsoft.AspNetCore.Mvc;
using MvcSeriesPersonajesDCC.Models;
using MvcSeriesPersonajesDCC.Repositories;

namespace MvcSeriesPersonajesDCC.Controllers
{
    public class SeriesController : Controller
    {
        //Llamamos al repositorio para poder usarlo desde el controlador
        private RepositorySeries repo;
        public SeriesController(RepositorySeries repo)
        {
            this.repo = repo;
        }
        // Desde la vista Index, llamamos a la lista de series
        public IActionResult Index()
        {
            List<Series> seriesList = this.repo.GetSeries();
            return View(seriesList);
        }
        // Desde la vista Details, llamamos a los detalles de la serie
        // Recibiendo la ID
        public IActionResult Details(int id)
        {
            Series serie = this.repo.GetUniqueSerie(id);
            return View(serie);
        }

        // Creamos una Vista para crear una nueva serie
        // Tras crearse lo devolvemos a la vista Index
        // Para visualizar todas las series y ver la nueva
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Series series)
        {
            this.repo.AddSeries(series.IdSerie, series.Nombre, series.Imagen, series.Anyo);
            return RedirectToAction("Index");
        }

        // Creamos una vista para visualizar los personajes de una serie
        public ActionResult Characters(int id) 
        {
            List<Personajes> personajes = this.repo.ShowCharacters(id);
            return View(personajes);
        }
    }
}
