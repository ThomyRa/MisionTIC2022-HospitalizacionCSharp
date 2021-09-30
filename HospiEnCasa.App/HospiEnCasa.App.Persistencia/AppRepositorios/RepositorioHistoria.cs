using System;
using System.Collections.Generic;
using System.Linq;
using HospiEnCasa.App.Dominio;

namespace HospiEnCasa.App.Persistencia
{
    public class RepositorioHistoria : IRepositorioHistoria
    {
        private readonly AppContext _appContext;

        public RepositorioHistoria(AppContext appContext)
        {
            _appContext = appContext;
        }

        Historia IRepositorioHistoria.AddHistoria(Historia historia)
        {
            var historiaAdicionada = _appContext.Historias.Add(historia);
            _appContext.SaveChanges();
            return historiaAdicionada.Entity;
        }
        void IRepositorioHistoria.DeleteHistoria(int idHistoria)
        {
            var historiaEncontrada = _appContext.Historias.FirstOrDefault(p => p.Id == idHistoria);
            if (historiaEncontrada == null)
                return;

            _appContext.Historias.Remove(historiaEncontrada);
            _appContext.SaveChanges();
        }
        IEnumerable<Historia> IRepositorioHistoria.GetAllHistoria()
        {
            return _appContext.Historias;
        }
        Historia IRepositorioHistoria.GetHistoria(int idHistoria)
        {
            var historiaEncontrada = _appContext.Historias.FirstOrDefault(p => p.Id == idHistoria);
            return historiaEncontrada;
        }
        Historia IRepositorioHistoria.UpdateHistoria(Historia historia)
        {
            var historiaEncontrada = _appContext.Historias.FirstOrDefault(p => p.Id == historia.Id);
            if (historiaEncontrada != null)
            {
                historiaEncontrada.Diagnostico = historia.Diagnostico;
                historiaEncontrada.Entorno = historia.Entorno;
                historiaEncontrada.SugerenciasCuidado = historia.SugerenciasCuidado;

                _appContext.SaveChanges();
            }
            return historiaEncontrada;
        }
        List<SugerenciaCuidado> IRepositorioHistoria.AsignarSugerenciaCuidado(int idHistoria, int idSugerenciaCuidado)
        {
            var historiaEncontrada = _appContext.Historias.FirstOrDefault(h => h.Id == idHistoria);
            if (historiaEncontrada != null)
            {
                var sugerenciaCuidadoEncontradas = _appContext.SugerenciasCuidado.Where(sc => sc.Id == idSugerenciaCuidado);
                if (sugerenciaCuidadoEncontradas != null)
                {
                    historiaEncontrada.SugerenciasCuidado = sugerenciaCuidadoEncontradas.ToList();
                    foreach (var sugerencias in historiaEncontrada.SugerenciasCuidado)
                    {
                        Console.WriteLine($"Sugerencia cuidado: {sugerencias.Description}");
                    }
                    _appContext.SaveChanges();
                }
                return historiaEncontrada.SugerenciasCuidado;
            }
            return null;
        }

    }
}