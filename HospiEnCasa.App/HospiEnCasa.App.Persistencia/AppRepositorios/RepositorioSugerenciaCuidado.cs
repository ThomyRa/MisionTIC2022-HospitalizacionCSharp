using System;
using System.Collections.Generic;
using System.Linq;
using HospiEnCasa.App.Dominio;

namespace HospiEnCasa.App.Persistencia
{
    public class RepositorioSugerenciaCuidado : IRepositorioSugerenciaCuidado
    {
        private readonly AppContext _appContext;

        public RepositorioSugerenciaCuidado(AppContext appContext)
        {
            _appContext = appContext;
        }
        SugerenciaCuidado IRepositorioSugerenciaCuidado.AddSugerenciaCuidado(SugerenciaCuidado sugerenciaCuidado)
        {
            var sugerenciaCuidadoAdicionada = _appContext.SugerenciasCuidado.Add(sugerenciaCuidado);
            _appContext.SaveChanges();
            return sugerenciaCuidadoAdicionada.Entity;
        }
        void IRepositorioSugerenciaCuidado.DeleteSugerenciaCuidado(int idSugerenciaCuidado)
        {
            var sugerenciaCuidadoEncontrada = _appContext.SugerenciasCuidado.FirstOrDefault(p => p.Id == idSugerenciaCuidado);
            if (sugerenciaCuidadoEncontrada == null)
                return;

            _appContext.SugerenciasCuidado.Remove(sugerenciaCuidadoEncontrada);
            _appContext.SaveChanges();
        }
        IEnumerable<SugerenciaCuidado> IRepositorioSugerenciaCuidado.GetAllSugerenciaCuidado()
        {
            return _appContext.SugerenciasCuidado;
        }
        SugerenciaCuidado IRepositorioSugerenciaCuidado.GetSugerenciaCuidado(int idSugerenciaCuidado)
        {
            var sugerenciaCuidadoEncontrada = _appContext.SugerenciasCuidado.FirstOrDefault(p => p.Id == idSugerenciaCuidado);
            return sugerenciaCuidadoEncontrada;
        }
        SugerenciaCuidado IRepositorioSugerenciaCuidado.UpdateSugerenciaCuidado(SugerenciaCuidado sugerenciaCuidado)
        {
            var sugerenciaCuidadoEncontrada = _appContext.SugerenciasCuidado.FirstOrDefault(p => p.Id == sugerenciaCuidado.Id);
            if (sugerenciaCuidadoEncontrada != null)
            {
                sugerenciaCuidadoEncontrada.FechaHora = sugerenciaCuidado.FechaHora;
                sugerenciaCuidadoEncontrada.Description = sugerenciaCuidado.Description;

                _appContext.SaveChanges();
            }
            return sugerenciaCuidadoEncontrada;
        }
    }
}