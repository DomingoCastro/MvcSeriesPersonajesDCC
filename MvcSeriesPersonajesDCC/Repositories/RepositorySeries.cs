using MvcSeriesPersonajesDCC.Data;
using MvcSeriesPersonajesDCC.Models;

namespace MvcSeriesPersonajesDCC.Repositories
{
    public class RepositorySeries
    {
        private SeriesContext context;

        public RepositorySeries(SeriesContext context)
        {
            this.context = context;
        }

        // Metodo para devolver todas las series

        public List<Series> GetSeries()
        {
            var consulta = from datos in this.context.Series
                           select datos;
            return consulta.ToList();
        }

        // Metodo para buscar una serie por su ID

        public Series GetUniqueSerie(int id)
        {
            var consulta = from datos in this.context.Series
                           where datos.IdSerie == id
                           select datos;
            return consulta.FirstOrDefault();
        }

        // Metodo para insertar una serie
        public void AddSeries(int id, string nombre, string imagen, int anyo)
        {
            Series serie = new Series();
            serie.IdSerie = id;
            serie.Nombre= nombre;
            serie.Imagen= imagen;
            serie.Anyo= anyo;
            this.context.Series.Add(serie);
            this.context.SaveChanges();
        }

        // Metodo para ver los personajes de una serie
        public List<Personajes> ShowCharacters(int id)
        {
            var consulta = from datos in this.context.Personajes
                           where datos.IdSerie == id
                           select datos;
            return consulta.ToList();
        }
    }
}
